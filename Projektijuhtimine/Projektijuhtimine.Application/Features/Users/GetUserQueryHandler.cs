using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Users;
public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User?> {
 private readonly ApplicationDbContext _db; public GetUserQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken) => await _db.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
}
