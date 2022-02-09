using BrushItem.Data;
using BrushItem.Shared.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BrushItem.Respository.Impl
{
    public class QuestionRepository: RepositoryBase<SingleChoice>, IQuestionRepository
    {
        private readonly BrushDbContext context;

        public QuestionRepository(BrushDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<SingleChoice> GetFirstQuestionAsync()
        {
            var first=await context.SingleChoices.FirstOrDefaultAsync();
            ////var QuestionDto = mapper.Map<QuestionDto>(first);
            //BrushDbContext.Set<SingleChoice>().SingleOrDefault();
            return first;
        }
    }
}
