using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.WorkLogs;
public class ListWorkLogsQueryHandler : IRequestHandler<ListWorkLogsQuery, IEnumerable<WorkLog>> {
 private readonly ApplicationDbContext _db; public ListWorkLogsQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<IEnumerable<WorkLog>> Handle(ListWorkLogsQuery request, CancellationToken cancellationToken) => await _db.WorkLogs.AsNoTracking().ToListAsync(cancellationToken);
}
