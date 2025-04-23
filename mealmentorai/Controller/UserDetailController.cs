using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Application.Features.UserDetails;
using Microsoft.AspNetCore.Authorization;
namespace Zmealmentorai.Controller
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("userdetails")]
        public async Task<IActionResult> CreateUserDetail([FromBody] CreateUserDetailRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("userdetails")]
        public async Task<IActionResult> UpdateUserDetail([FromBody] UpdateUserDetailRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("userdetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            var result = await _mediator.Send(new GetUserDetailsRequest());
            return Ok(result);
        }
    }
}