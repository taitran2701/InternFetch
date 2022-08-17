﻿using InternBA.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InternBA.Models
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly InternBADBContext context;
        public UserServiceRepository(UserManager<IdentityUser> userManager, InternBADBContext context)
        {
            _userManager = userManager;
            this.context = context;
        }

        public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user)
        {
            context.UserRefreshToken.Add(user);
            return user;
        }

        public void DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = context.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
            if (item != null)
            {
                context.UserRefreshToken.Remove(item);
            }
        }

        public UserRefreshTokens GetSavedRefreshTokens(string username, string refreshToken)
        {
            return context.UserRefreshToken.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive == true);
        }

        public Task<bool> IsValidUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public int SaveCommit()
        {
            throw new NotImplementedException();
        }
    }
}
