using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Tasks;
public class GetTaskQuery : IRequest<ProjectTask?> { public int Id { get; set; } }
