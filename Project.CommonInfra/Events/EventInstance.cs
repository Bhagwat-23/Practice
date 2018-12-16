using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CommonInfra.Events
{
	public class EventInstance
	{
		private static readonly EventInstance _instance = new EventInstance();
		public static EventInstance Instance { get { return _instance; } }

		private IEventAggregator eventAggregator;

		public IEventAggregator EventAggregator
		{
			get
			{
				if (eventAggregator == null)
					eventAggregator = new EventAggregator();
				return eventAggregator;
			}
		}

	}
}
