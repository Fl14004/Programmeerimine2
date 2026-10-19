using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Tasks;
public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, ProjectTask?> {
 private readonly ApplicationDbContext _db; public GetTaskQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<ProjectTask?> Handle(GetTaskQuery request, CancellationToken cancellationToken) => await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
}
