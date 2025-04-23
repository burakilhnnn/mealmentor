using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Histories;
using Microsoft.AspNetCore.Authorization;

namespace Zmealmentorai.Controller
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpDelete("histories")]
        public async Task<IActionResult> DeleteHistory([FromBody] DeleteHistoryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("histories")]
        public async Task<IActionResult> GetHistory([FromQuery] GetHistoryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}