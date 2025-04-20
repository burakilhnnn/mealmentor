using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Histories;

namespace Zmealmentorai.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("histories")]
        public async Task<IActionResult> CreateHistory([FromBody] CreateHistoryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}