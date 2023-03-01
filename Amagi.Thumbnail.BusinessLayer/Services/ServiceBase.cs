using Amagi.Thumbnail.DataLayer.Context;
using AutoMapper;

namespace Amagi.Thumbnail.BusinessLayer;

public abstract class ServiceBase
{
    public readonly AmagiContext _context;
    public readonly IMapper _mapper;

    public ServiceBase(AmagiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
