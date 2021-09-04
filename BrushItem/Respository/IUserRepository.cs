using BrushItem.Shared.Entities;
using BrushItem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrushItem.Respository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        
        List<User> GetUserAsync();
        void CreateUser(User user);
    }
}