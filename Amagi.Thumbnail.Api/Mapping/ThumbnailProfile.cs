using AutoMapper;
using M = Amagi.Thumbnail.DataLayer.Models;

namespace Amagi.Thumbnail.Api.Mapping;

public class ThumbnailProfile : Profile
{
    public ThumbnailProfile()
    {
        CreateMap<M.ThumbnailMeta, ThumbnailMetaModel>().ReverseMap();
    }
}
