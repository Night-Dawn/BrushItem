using AutoMapper;
using BrushItem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Respository.Impl
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly BrushDbContext context;
        private IQuestionRepository questionRepository = null;
        public RepositoryWrapper(BrushDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IQuestionRepository question
        {
            get 
            {
                questionRepository ??= new QuestionRepository(context);
                return questionRepository;
            }
        }
    }
}
