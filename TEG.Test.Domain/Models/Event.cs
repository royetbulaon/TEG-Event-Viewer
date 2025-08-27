using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEG.Test.Domain.Models
{
	public class Event
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime StartDate { get; set; }
		public int VenueId { get; set; }
		// Navigation property
		public Venue? Venue { get; set; }
	}
}
