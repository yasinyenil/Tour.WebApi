using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Tours.Commands;
using Application.Features.Tours.Commands.DeleteTourById;
using Application.Features.Tours.Commands.UpdateTour;
using Application.Features.Tours.Queries.GetAllTours;
using Application.Features.Tours.Queries.GetAllToursByTourDestination;
using Application.Features.Tours.Queries.GetTourByIdQuery;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TourController : BaseApiController
    {

        private readonly IAuthenticatedUserService _authenticatedUser;

        public TourController(IAuthenticatedUserService authenticatedUser)
        {
            _authenticatedUser = authenticatedUser;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTourParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllToursQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTourByIdQuery { Id = id }));
        }

        [HttpGet("get-criteria")]
        public async Task<IActionResult> GetCriteria([FromQuery] GetAllTourSearchParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllToursByTourDestinationQuery { FromWhere= filter.FromWhere, ToWhere = filter.ToWhere , UserId = _authenticatedUser.UserId }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateTourCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateTourCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTourByIdCommand { Id = id }));
        }
    }
}
