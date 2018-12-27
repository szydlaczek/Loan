﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanApp.Application.Loans.Commands.AddLoan;
using LoanApp.Application.Loans.Commands.PayLoan;
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
            var result= await _mediator.Send(command);
            if (result.Errors.Any())
                return BadRequest(result);
            return Created("", null);
        }

        [HttpPut]
        [Route("PayLoan/{id}")]
        public async Task<IActionResult> Put(int id)
        {
            var result = await _mediator.Send(new PayLoanCommand { LoanId = id });
            if (result.Errors.Any())
                return BadRequest(result);
            else
                return Ok();
        }
    }
}