using AutoMapper;
using BrushItem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Respository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly BrushDbContext context;
        private readonly IMapper mapper;
        private IUserRepository userRepository = null;
        public RepositoryWrapper(BrushDbContext context,IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IUserRepository User
        {
            get
            {
                userRepository ??= new UserRepository(context, mapper);
                return userRepository;
            }
        }
    }
}
