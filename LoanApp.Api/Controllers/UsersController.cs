using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanApp.Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
