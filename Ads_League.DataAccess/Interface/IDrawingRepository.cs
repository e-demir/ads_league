using System;
using Ads_League.Common.Models.Request;

namespace Ads_League.DataAccess
{
	public interface IDrawingRepository
	{
		void InsertDrawing(InsertDrawingResultRequest request);
	}
}

