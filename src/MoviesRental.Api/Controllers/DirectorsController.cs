using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesRental.Application.Services.Directors.Commands.DeleteDirector;
using MoviesRental.Application.Services.Directors.Commands.Write.CreateDirector;
using MoviesRental.Application.Services.Directors.Commands.Write.UpdateDirector;

namespace MoviesRental.Api.Controllers;
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class DirectorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DirectorsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    //[HttpGet("{action}/{fullName}")]
    //public async Task<ActionResult> GetDirector([FromRoute] string fullName)
    //{
    //    var query = new GetDirectorQuery(fullName);

    //    var result = await _mediator.Send(query, HttpContext.RequestAborted);

    //    if(result is null)
    //        return NotFound();

    //    return Ok(result);
    //}

    [HttpPost]
    public async Task<ActionResult<CreateDirectorReponse>> Post([FromBody] CreateDirectorCommand command)
    {
        var result = await _mediator.Send(command, HttpContext.RequestAborted);

        if(!result.IsValid)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateDirectorResponse>> Put([FromBody]  UpdateDirectorCommand command)
    {
        var result = await _mediator.Send(command, HttpContext.RequestAborted);

        if (!result.IsFound)
            return NotFound(result);

        if (!result.IsValid)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteDirectorCommand(id);

        var result = await _mediator.Send(command);

        if (!result.IsFound)
            return NotFound(result);

        return NoContent();
    }
}
