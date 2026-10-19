using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Tasks;
public class ListTasksQuery : IRequest<IEnumerable<ProjectTask>> { }
