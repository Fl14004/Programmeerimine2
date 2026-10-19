using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Tasks;
public class ListTasksQueryHandler : IRequestHandler<ListTasksQuery, IEnumerable<ProjectTask>> {
 private readonly ApplicationDbContext _db; public ListTasksQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<IEnumerable<ProjectTask>> Handle(ListTasksQuery request, CancellationToken cancellationToken) => await _db.Tasks.AsNoTracking().ToListAsync(cancellationToken);
}
