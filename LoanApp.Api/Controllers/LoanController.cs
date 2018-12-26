using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanApp.Application.Loans.Commands.AddLoan;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddLoanCommand command)
        {
            await _mediator.Send(command);
            return Created("", null);
        }
    }
}