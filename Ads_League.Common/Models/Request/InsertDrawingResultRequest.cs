using System;
using System.Text.RegularExpressions;

namespace Ads_League.Common.Models.Request
{
	public class InsertDrawingResultRequest
	{
        public string? DrawerInformation { get; set; }
        public List<GroupModel> Groups { get; set; }
    }
}

