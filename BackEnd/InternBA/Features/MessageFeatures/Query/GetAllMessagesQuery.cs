using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.MessageFeatures.Query
{
    public record GetAllMessagesQuery(PageParagram page) : IRequest<PagedList<Message>>
    {
        public class GetAllMessagesQueryHanler : IRequestHandler<GetAllMessagesQuery, PagedList<Message>>
        {
            private readonly InternBADBContext _context;
            public GetAllMessagesQueryHanler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<PagedList<Message>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
            {
                var messages = PagedList<Message>.ToPageList(_context.Messages.ToList().AsQueryable(), request.page.PageNumber, request.page.PageSize);

                return messages;
            }
        }
    }
}
