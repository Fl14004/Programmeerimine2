using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.ProjectMembers;
public class ListProjectMembersQueryHandler : IRequestHandler<ListProjectMembersQuery, IEnumerable<ProjectMember>> {
 private readonly ApplicationDbContext _db; public ListProjectMembersQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<IEnumerable<ProjectMember>> Handle(ListProjectMembersQuery request, CancellationToken cancellationToken) => await _db.ProjectMembers.AsNoTracking().ToListAsync(cancellationToken);
}
