using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Application.Features.UserDetails;

namespace Zmealmentorai.Controller
{
    [Route("[controller]")]
    [ApiController]
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
    }
}