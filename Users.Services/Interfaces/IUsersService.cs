using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Models.Users;

namespace Users.Services.Interfaces
{
    public interface IUsersService
    {
        Task<List<UserModel>> GetAsync();
        Task<UserModel> GetByIdAsync(Guid id);
        Task<UserModel> CreateAsync(UserModel model);
        Task<UserModel> UpdateAsync(UserModel model);
        Task RemoveAsync(Guid id);
    }
}
