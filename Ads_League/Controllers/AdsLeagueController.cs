using Ads_League.Business;
using Ads_League.Common;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;

namespace Ads_League.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdsLeagueController : ControllerBase
    {
        private readonly IBusinessLayer _businessLayer;

        public AdsLeagueController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpPost("MakeDrawing")]
        public ActionResult MakeDrawing (MakeDrawingRequestModel request)
        {
            Guard.Against.Null(request);
            Guard.Against.NullOrEmpty(request.Name);
            Guard.Against.NullOrEmpty(request.SurName);
            if (request.GroupCount != 4 && request.GroupCount != 8)
            {
                return BadRequest("Group number must be 4 or 8.");
            }

            var response = _businessLayer.MakeDrawing(request);
            return Ok(response);
        }
    }
}

