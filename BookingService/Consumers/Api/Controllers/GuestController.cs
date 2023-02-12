using Application.Base;
using Application.Guest.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestController(ILogger<GuestController> logger, IGuestManager guestManager)
        {
            _logger = logger;
            _guestManager = guestManager;
        }


        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
        {
            var req = new CreateGuestRequest
            {
                Data = guest
            };

            var res = await _guestManager.CreateGuest(req);

            if (res.Success) return Created("", res.Data);
            if (Enum.IsDefined(typeof(ErrorCodes), res.ErrorCode)) return BadRequest(res);


            _logger.LogError("Response with unknow ErrorCode Returned", res);
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<GuestDTO>> Get(int id)
        {
            var res = await _guestManager.GetGuest(id);
            if (res.Success) return Ok(res.Data);
            return NotFound(res);
        }
    }
}
