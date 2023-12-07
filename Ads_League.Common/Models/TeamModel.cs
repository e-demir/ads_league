using System;
namespace Ads_League.Common
{
	public class TeamModel
	{
        public string? TeamName { get; set; }

        public bool IsSelected { get; set; }

        public CountryModel? Country { get; set; }
    }
}

