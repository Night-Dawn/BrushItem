using BrushItem.Shared.Entities;
using BrushItem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.Respository
{
    public interface IQuestionRepository: IRepositoryBase<SingleChoice>
    {
        Task<SingleChoice> GetFirstQuestionAsync(); 
    }
}
