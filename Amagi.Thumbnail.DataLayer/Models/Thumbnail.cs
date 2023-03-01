namespace Amagi.Thumbnail.DataLayer.Models;

public class Thumbnail
{
    public int Id { get; set; }
    public int ThumbnailMetaId { get; set; }
    public byte[] ThumbnailImage { get; set; }

    public virtual ThumbnailMeta? ThumbnailMeta { get; set; }
}
