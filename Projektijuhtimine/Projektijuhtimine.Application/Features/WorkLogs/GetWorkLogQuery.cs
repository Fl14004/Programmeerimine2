using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.WorkLogs;
public class GetWorkLogQuery : IRequest<WorkLog?> { public int Id { get; set; } }
