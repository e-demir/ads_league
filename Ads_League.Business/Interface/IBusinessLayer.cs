using Ads_League.Common;

namespace Ads_League.Business
{
	public interface IBusinessLayer
	{
        MakeDrawingResponseModel MakeDrawing(MakeDrawingRequestModel request);
    }
}

