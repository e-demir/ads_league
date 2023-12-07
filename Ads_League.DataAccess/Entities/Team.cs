using System;
namespace Ads_League.DataAccess.Entities
{
	public class Team
	{
		public Guid Id { get; set; }
        public string TeamName { get; set; }

        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}

