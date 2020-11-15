using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Reservations.Commands.CreateReservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ReservationController : BaseApiController
    {
       
        //You can reserve a tour and seat
        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateReservationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
