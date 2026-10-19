using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Users;
public class GetUserQuery : IRequest<User?> { public int Id { get; set; } }
