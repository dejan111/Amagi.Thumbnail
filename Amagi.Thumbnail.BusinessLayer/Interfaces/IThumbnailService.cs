using M = Amagi.Thumbnail.DataLayer.Models;

namespace Amagi.Thumbnail.BusinessLayer;

public interface IThumbnailService
{
    ValueTask<M.ThumbnailMeta> GetThumbnailMetaById(int id, CancellationToken ct);
    ValueTask<(Stream? thumbnailImage, bool? isProcessed)> GetThumbnailImageById(int id, CancellationToken ct);
    ValueTask<M.ThumbnailMeta> CreateThumbnailMeta(M.ThumbnailMeta thumbnailMeta, CancellationToken ct);
    ValueTask<IEnumerable<M.ThumbnailMeta>> GetThumbnails(bool? isProcessed, CancellationToken ct);
    ValueTask SetIsProcessed(int id, bool isProcessed, CancellationToken ct);
    ValueTask CreateThumbnail(M.Thumbnail thumbnail, CancellationToken ct);
}
