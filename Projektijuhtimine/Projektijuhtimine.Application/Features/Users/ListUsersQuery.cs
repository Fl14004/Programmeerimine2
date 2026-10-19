using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Users;
public class ListUsersQuery : IRequest<IEnumerable<User>> { }
