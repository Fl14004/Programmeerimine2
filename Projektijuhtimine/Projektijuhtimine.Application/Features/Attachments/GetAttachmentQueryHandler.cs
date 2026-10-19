using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Attachments;
public class GetAttachmentQueryHandler : IRequestHandler<GetAttachmentQuery, Attachment?> {
 private readonly ApplicationDbContext _db; public GetAttachmentQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<Attachment?> Handle(GetAttachmentQuery request, CancellationToken cancellationToken) => await _db.Attachments.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
}
