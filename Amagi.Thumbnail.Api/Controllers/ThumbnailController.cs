using Amagi.Thumbnail.BusinessLayer;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Amagi.Thumbnail.Api.Controllers;

[ApiController]
public class ThumbnailController : ControllerBase
{
    private readonly IThumbnailService _service;
    private readonly IMapper _mapper;

    public ThumbnailController(IThumbnailService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("thumbnail/{id:int}")]
    public async ValueTask<IActionResult> GetById(int id, CancellationToken ct)
    {
        (Stream stream, bool? isProcess) = await _service.GetThumbnailImageById(id, ct);
        if (stream == null)
            return NotFound();

        if (!isProcess.GetValueOrDefault())
            return StatusCode(503);

        return File(stream, "image/jpeg");
    }

    [HttpPost]
    [Route("thumbnail")]
    public async ValueTask<ActionResult<int>> Save([FromBody] ThumbnailMetaModel thumbnailMetaModel, CancellationToken ct)
    {
        var thumbnailMeta = _mapper.Map<DataLayer.Models.ThumbnailMeta>(thumbnailMetaModel);
        thumbnailMeta = await _service.CreateThumbnailMeta(thumbnailMeta, ct);

        return Ok(thumbnailMeta.Id);
    }

}
