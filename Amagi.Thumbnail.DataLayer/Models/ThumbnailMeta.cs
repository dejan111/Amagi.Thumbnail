namespace Amagi.Thumbnail.DataLayer.Models;

public class ThumbnailMeta
{
    public int Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Url { get; set; }
    public bool IsProcessed { get; set; }

    public virtual Thumbnail? Thumbnail { get; set; }
}