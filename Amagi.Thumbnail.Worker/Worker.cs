using Amagi.Thumbnail.BusinessLayer;
using SixLabors.ImageSharp.Formats.Png;

namespace Amagi.Thumbnail.Worker;

public class Worker
{
    private readonly IThumbnailService _service;

    public Worker(IThumbnailService service)
    {
        _service = service;
    }

    public async Task<bool> ProcessData(CancellationToken ct)
    {
        var unprocessedThumbnails = await _service.GetThumbnails(isProcessed: false, ct);

        foreach (var thumbnail in unprocessedThumbnails)
        {
            var thumbnailImage = await GetBinaryFromUrl(thumbnail.Url);
            var resizedThumbnailImage = ResizeImage(thumbnailImage, thumbnail.Width, thumbnail.Height);

            if (resizedThumbnailImage != null)
            {
                var resizedThumbnail = new DataLayer.Models.Thumbnail()
                {
                    ThumbnailImage = resizedThumbnailImage,
                    ThumbnailMetaId = thumbnail.Id
                };

                await _service.CreateThumbnail(resizedThumbnail, ct);
                await _service.SetIsProcessed(thumbnail.Id, isProcessed: true, ct);
            }
        }

        return true;
    }

    private static async ValueTask<byte[]> GetBinaryFromUrl(string url)
    {
        using var client = new HttpClient();
        using var result = await client.GetAsync(url);
        return result.IsSuccessStatusCode ? await result.Content.ReadAsByteArrayAsync() : null;
    }

    private static byte[] ResizeImage(byte[] image, int width, int height)
    {
        var resizedImage = Image.Load<Rgba32>(image);
        resizedImage.Mutate(x => x.Resize(width, height));

        using var ms = new MemoryStream();
        resizedImage.Save(ms, PngFormat.Instance);
        return ms.ToArray();
    }
}
