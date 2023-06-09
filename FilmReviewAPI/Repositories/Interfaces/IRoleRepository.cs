﻿using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        public Task<Role> GetRoleByNameAsync(string name);
    }
}
