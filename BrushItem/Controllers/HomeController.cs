using AutoMapper;
using BrushItem.Data;
using BrushItem.Respository;
using BrushItem.Shared.Entities;
using BrushItem.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "V1")]
    public class HomeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public HomeController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        //[Authorize]
        [HttpGet(Name = nameof(getUsers))]
        public async Task<IActionResult> getUsers()
        {
            var question= await _repositoryWrapper.question.GetFirstQuestionAsync();
            var qusetionDto=_mapper.Map<QuestionDto>(question);
            //var name = HttpContext.User.Identity.Name;

            //var blogs = repositoryWrapper.User.GetUserAsync();
            //var rand = new Random();
            //var query = from user in context.Users
            //             select user;
            //var result = from user in query.AsEnumerable()
            //             orderby rand.Next(0, 2)
            //             select user;
            //var queryExpression = context.Users as IQueryable<User>;
            //var sr = context.Set<User>().
            return Ok(qusetionDto);
        }
        //[HttpPost]
        //public async Task<IActionResult> addUser(UserAddDto userAddDto)
        //{
        //    var user = mapper.Map<User>(userAddDto);
        //    repositoryWrapper.User.Create(user);
        //    await repositoryWrapper.User.SaveAsync();
        //    return CreatedAtRoute(nameof(getUsers), new { }, user);
        //}
    }
}
