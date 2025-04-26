using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Foods;
using Microsoft.AspNetCore.Authorization;

namespace mealmentorai.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-food")]
        public async Task<IActionResult> CreateFood([FromBody] CreateFoodRequest request)
        {
            var foods = await _mediator.Send(request);
            return Ok(foods);
        }
    }
}