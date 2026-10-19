using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Attachments;
public class ListAttachmentsQuery : IRequest<IEnumerable<Attachment>> { }
