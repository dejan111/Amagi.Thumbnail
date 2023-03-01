using Amagi.Thumbnail.DataLayer.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using M = Amagi.Thumbnail.DataLayer.Models;

namespace Amagi.Thumbnail.BusinessLayer;

public class ThumbnailService : ServiceBase, IThumbnailService
{
    public ThumbnailService(AmagiContext context, IMapper mapper) : base(context, mapper)
    { }

    public async ValueTask<M.ThumbnailMeta> GetThumbnailMetaById(int id, CancellationToken ct)
    {
        M.ThumbnailMeta thumbnail = await _context.ThumbnailMeta.AsNoTracking().Where(x => x.Id == id).Include(x => x.Thumbnail).FirstOrDefaultAsync(cancellationToken: ct);
        return thumbnail;
    }

    public async ValueTask<(Stream? thumbnailImage, bool? isProcessed)> GetThumbnailImageById(int id, CancellationToken ct)
    {
        var thumbnailMeta = await GetThumbnailMetaById(id, ct);

        if (thumbnailMeta?.Thumbnail?.ThumbnailImage != null)
        {
            MemoryStream stream = new();
            stream.Write(thumbnailMeta.Thumbnail.ThumbnailImage, 0, thumbnailMeta.Thumbnail.ThumbnailImage.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return (stream, thumbnailMeta.IsProcessed);
        }

        return (null, null);
    }

    public async ValueTask<IEnumerable<M.ThumbnailMeta>> GetThumbnails(bool? isProcessed, CancellationToken ct)
    {
        IEnumerable<M.ThumbnailMeta> thumbnails = await _context.ThumbnailMeta.Where(x => x.IsProcessed == isProcessed.GetValueOrDefault()).ToListAsync(cancellationToken: ct);
        return thumbnails;
    }

    public async ValueTask<M.ThumbnailMeta> CreateThumbnailMeta(M.ThumbnailMeta thumbnailMeta, CancellationToken ct)
    {
        await _context.ThumbnailMeta.AddAsync(thumbnailMeta, ct);
        await _context.SaveChangesAsync(ct);

        return thumbnailMeta;
    }

    public async ValueTask SetIsProcessed(int id, bool isProcessed, CancellationToken ct)
    {
        M.ThumbnailMeta thumbnail = await _context.ThumbnailMeta.Where(x => x.Id == id).Include(x => x.Thumbnail).FirstOrDefaultAsync(cancellationToken: ct);
        if (thumbnail != null)
            thumbnail.IsProcessed = isProcessed;

        await _context.SaveChangesAsync(ct);
    }

    public async ValueTask CreateThumbnail(M.Thumbnail thumbnail, CancellationToken ct)
    {
        await _context.Thumbnail.AddAsync(thumbnail, ct);
        await _context.SaveChangesAsync(ct);
    }
}
