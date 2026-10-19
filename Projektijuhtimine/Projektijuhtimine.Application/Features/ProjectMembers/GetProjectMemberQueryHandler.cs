using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.ProjectMembers;
public class GetProjectMemberQueryHandler : IRequestHandler<GetProjectMemberQuery, ProjectMember?> {
 private readonly ApplicationDbContext _db; public GetProjectMemberQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<ProjectMember?> Handle(GetProjectMemberQuery request, CancellationToken cancellationToken) => await _db.ProjectMembers.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
}
