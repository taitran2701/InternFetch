﻿using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetAllUsersQuery(PageParagram pagination) : IRequest<PagedList<User>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedList<User>>
        {
            private readonly InternBADBContext context;

            public GetAllUsersQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<PagedList<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                //var list = await context.Users.Include(user => user.UserRooms)
                //    .ThenInclude(userRoom => userRoom.Room)
                //    .ToListAsync();
                //var hashset = new HashSet<Room>(list);
                //foreach (var item in list)
                //{
                //    Console.WriteLine(item.Room['user2']);
                //}
                var users = PagedList<User>.ToPageList(context.Users.ToList().AsQueryable(), request.pagination.PageNumber, request.pagination.PageSize);

                return users;
            }
        }
    }
}
