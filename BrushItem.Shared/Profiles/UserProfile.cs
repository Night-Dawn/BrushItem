using AutoMapper;
using BrushItem.Shared.Entities;
using BrushItem.Shared.Models;

namespace BrushItem.Shared.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>().ReverseMap();
        }
    }
}