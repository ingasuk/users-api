using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Data;
using Users.Data.Entities;
using Users.Models.Users;
using Users.Services.Interfaces;

namespace Users.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UsersService(
            IRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetAsync()
        {
            var users = await _userRepository.GetAll().ToListAsync();
            users = OrderUsers(users);

            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (user != null)
            {
                return _mapper.Map<UserModel>(user);
            }

            return null;
        }

        public async Task<UserModel> CreateAsync(UserModel model)
        {
            var user = _mapper.Map<UserEntity>(model);
            var createdUser = await _userRepository.InsertAsync(user);

            return _mapper.Map<UserModel>(createdUser);
        }

        public async Task<UserModel> UpdateAsync(UserModel model)
        {
            var user = await _userRepository.GetFirstWhereAsync(x => x.Id == model.Id);

            if (user != null)
            {
                user = _mapper.Map(model, user);
                var updatedUser = await _userRepository.UpdateAsync(user);

                return _mapper.Map<UserModel>(updatedUser);
            }

            return null;

        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await _userRepository.GetFirstWhereAsync(x => x.Id == id);

            if (user != null)
            {
                await _userRepository.DeleteFromDbAsync(user);
            }

        }

        private static List<UserEntity> OrderUsers(List<UserEntity> users)
        {
            users = users.OrderBy(u => u.FirstName).ThenBy(u => u.LastName).ToList();

            return users;
        }

    }
}
