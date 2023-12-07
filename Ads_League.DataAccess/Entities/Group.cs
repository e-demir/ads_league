using System;
namespace Ads_League.DataAccess.Entities
{
	public class Group
	{
		public Guid Id { get; set; }
        public string GroupName { get; set; }

        public Guid DrawingId { get; set; }
        public virtual Drawing Drawing { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}

