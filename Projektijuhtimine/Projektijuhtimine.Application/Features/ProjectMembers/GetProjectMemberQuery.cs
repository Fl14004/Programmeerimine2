using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.ProjectMembers;
public class GetProjectMemberQuery : IRequest<ProjectMember?> { public int Id { get; set; } }
