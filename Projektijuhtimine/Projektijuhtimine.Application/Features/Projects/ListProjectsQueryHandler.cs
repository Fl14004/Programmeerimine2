using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Projects;
public class ListProjectsQueryHandler : IRequestHandler<ListProjectsQuery, IEnumerable<Project>> {
 private readonly ApplicationDbContext _db; public ListProjectsQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<IEnumerable<Project>> Handle(ListProjectsQuery request, CancellationToken cancellationToken) => await _db.Projects.AsNoTracking().ToListAsync(cancellationToken);
}
