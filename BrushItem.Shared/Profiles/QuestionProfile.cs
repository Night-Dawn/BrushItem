using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrushItem.Shared.Entities;
using BrushItem.Shared.Models;
namespace BrushItem.Shared.Profiles
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<SingleChoice, QuestionDto>().ForMember(
                dest=>dest.Options,
                opt=> {
                    opt.MapFrom(src => new List<string> { src.optionA, src.optionB, src.optionC, src.optionD });
                });
        }
    }
}
