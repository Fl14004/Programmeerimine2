using MediatR;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Attachments;
public class GetAttachmentQuery : IRequest<Attachment?> { public int Id { get; set; } }
