using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Projects;
public class ListProjectsQuery : IRequest<IEnumerable<Project>> { }
