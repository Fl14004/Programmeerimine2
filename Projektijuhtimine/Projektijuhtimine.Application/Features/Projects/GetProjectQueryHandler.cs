using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Projects;
public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, Project?> {
 private readonly ApplicationDbContext _db; public GetProjectQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<Project?> Handle(GetProjectQuery request, CancellationToken cancellationToken) => await _db.Projects.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
}
