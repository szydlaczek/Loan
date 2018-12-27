using LoanApp.Application.Users.Commands.CreateUser;
using LoanApp.Application.Users.Queries;
using LoanApp.Application.Users.Queries.GetUserBorrows;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            var result=await _mediator.Send(command);
            if (result.Errors.Any())
                return BadRequest(result);
            else
                return Created("", null);
            
        }
        [HttpGet]
        [Route("{id}/loans")]
        public async Task<IActionResult> Get(int id)
        {
            var response =await  _mediator.Send(new GetUserBorrowsQuery { UserId = id });
            return Ok(response.Result);
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLendersAndBorrowersQuery());
            return Ok(result);
        }       
    }
}
