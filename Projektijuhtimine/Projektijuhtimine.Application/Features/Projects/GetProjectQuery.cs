using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Projects;
public class GetProjectQuery : IRequest<Project?> { public int Id { get; set; } }
