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

        [HttpPost]
        public MakeDrawingResponseModel MakeDrawing (MakeDrawingRequestModel request)
        {
            Guard.Against.Null(request);
            Guard.Against.NullOrEmpty(request.Name);
            Guard.Against.NullOrEmpty(request.SurName);
           
            var response = _businessLayer.MakeDrawing(request);
            return response;
        }
    }
}

