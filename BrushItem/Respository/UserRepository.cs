using AutoMapper;
using BrushItem.Data;
using BrushItem.Shared.Entities;
using BrushItem.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Respository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly BrushDbContext context;
        private readonly IMapper mapper;

        public UserRepository(BrushDbContext context,IMapper mapper):base(context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void CreateUser(User user)
        {
            context.Users.Add(user);
        }

        public List<User> GetUserAsync()
        {
            string sql = @"SELECT `u`.`id`, `u`.`name`, `u`.`username`
                        FROM `user` AS `u`
                        ORDER BY RAND() limit 2";
            var blogs = context.Users
            .FromSqlRaw(sql)
            .ToList();
            return blogs;
        }
    }
}