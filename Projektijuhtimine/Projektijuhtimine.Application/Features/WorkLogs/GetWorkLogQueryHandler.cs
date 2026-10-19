using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.WorkLogs;
public class GetWorkLogQueryHandler : IRequestHandler<GetWorkLogQuery, WorkLog?> {
 private readonly ApplicationDbContext _db; public GetWorkLogQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<WorkLog?> Handle(GetWorkLogQuery request, CancellationToken cancellationToken) => await _db.WorkLogs.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
}
