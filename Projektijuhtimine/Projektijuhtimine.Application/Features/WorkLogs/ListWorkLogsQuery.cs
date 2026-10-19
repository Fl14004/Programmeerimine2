using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.WorkLogs;
public class ListWorkLogsQuery : IRequest<IEnumerable<WorkLog>> { }
