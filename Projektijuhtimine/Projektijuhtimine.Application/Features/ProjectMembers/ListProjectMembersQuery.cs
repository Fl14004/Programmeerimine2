using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.ProjectMembers;
public class ListProjectMembersQuery : IRequest<IEnumerable<ProjectMember>> { }
