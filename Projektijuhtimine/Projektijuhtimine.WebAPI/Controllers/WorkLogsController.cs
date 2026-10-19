using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projektijuhtimine.Application.Features.WorkLogs;
namespace Projektijuhtimine.WebAPI.Controllers;
public class WorkLogsController : ApiControllerBase {
 private readonly IMediator _mediator; public WorkLogsController(IMediator mediator) => _mediator=mediator;
 [HttpGet("get/{id:int}")] public async Task<IActionResult> Get(int id) { if (id <= 0) return NotFound(); var result = await _mediator.Send(new GetWorkLogQuery { Id=id }); if (result is null) return NotFound(); return Ok(result); }
 [HttpGet("list")] public async Task<IActionResult> List() { var result = await _mediator.Send(new ListWorkLogsQuery()); return Ok(result); }
}
