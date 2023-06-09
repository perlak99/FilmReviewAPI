﻿using FilmReviewAPI.Models;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateUserAsync(string username, string password);

        Task<User> RegisterUserAsync(string username, string password);

        Task GrantRole(int userId, int roleId);
    }
}
