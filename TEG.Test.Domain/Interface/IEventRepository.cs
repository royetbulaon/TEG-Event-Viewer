using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEG.Test.Domain.Models;

namespace TEG.Test.Domain.Interface
{
	public interface IEventRepository
	{
		Task<EventData?> GetEventsAndVenuesAsync();
	}

}
