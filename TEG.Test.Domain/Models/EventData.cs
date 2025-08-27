using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEG.Test.Domain.Models
{
	public class EventData
	{
		public List<Event> Events { get; set; } = new();
		public List<Venue> Venues { get; set; } = new();
	}
}
