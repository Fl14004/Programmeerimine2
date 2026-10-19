using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Users;
public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<User>> {
 private readonly ApplicationDbContext _db; public ListUsersQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<IEnumerable<User>> Handle(ListUsersQuery request, CancellationToken cancellationToken) => await _db.Users.AsNoTracking().ToListAsync(cancellationToken);
}
