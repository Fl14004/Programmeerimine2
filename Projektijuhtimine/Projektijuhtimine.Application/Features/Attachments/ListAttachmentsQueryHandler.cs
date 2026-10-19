using MediatR;
using Microsoft.EntityFrameworkCore;
using Projektijuhtimine.Application.Data;
namespace Projektijuhtimine.Application.Features.Attachments;
public class ListAttachmentsQueryHandler : IRequestHandler<ListAttachmentsQuery, IEnumerable<Attachment>> {
 private readonly ApplicationDbContext _db; public ListAttachmentsQueryHandler(ApplicationDbContext db) => _db=db;
 public async Task<IEnumerable<Attachment>> Handle(ListAttachmentsQuery request, CancellationToken cancellationToken) => await _db.Attachments.AsNoTracking().ToListAsync(cancellationToken);
}
