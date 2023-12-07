using System;
namespace Ads_League.DataAccess.Entities
{
	public class Drawing
	{
		public Guid Id { get; set; }
        public string? DrawerInformation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<Group> Groups { get; set; }        
    }
}

