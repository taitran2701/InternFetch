using InternBA.Features.MessageFeatures.Query;
using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.RoomFeatures.Query
{
    public record GetAllRoomsQuery(PageParagram page) : IRequest<PagedList<Room>>
    {
        public class GetAllMessagesQueryHanler : IRequestHandler<GetAllRoomsQuery, PagedList<Room>>
        {
            private readonly InternBADBContext _context;
            public GetAllMessagesQueryHanler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<PagedList<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
            {
                var rooms = PagedList<Room>.ToPageList(_context.Rooms.ToList().AsQueryable(), request.page.PageNumber, request.page.PageSize);

                return rooms;
            }
        }
    }
}
