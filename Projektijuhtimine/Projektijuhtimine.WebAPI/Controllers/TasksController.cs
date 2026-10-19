using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projektijuhtimine.Application.Features.Tasks;
namespace Projektijuhtimine.WebAPI.Controllers;
public class TasksController : ApiControllerBase {
 private readonly IMediator _mediator; public TasksController(IMediator mediator) => _mediator=mediator;
 [HttpGet("get/{id:int}")] public async Task<IActionResult> Get(int id) { if (id <= 0) return NotFound(); var result = await _mediator.Send(new GetTaskQuery { Id=id }); if (result is null) return NotFound(); return Ok(result); }
 [HttpGet("list")] public async Task<IActionResult> List() { var result = await _mediator.Send(new ListTasksQuery()); return Ok(result); }
}
