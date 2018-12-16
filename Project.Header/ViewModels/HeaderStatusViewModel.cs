using Prism.Events;
using Project.CommonInfra.BaseClass;
using Project.CommonInfra.Events;
using Project.Header.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Header.ViewModels
{
	public class HeaderStatusViewModel:BindableBase, IHeaderStatus
	{
		public IEventAggregator eventAgg { get; set; }

		private string status;
		public string Status
		{
			get { return status; }
			set { status = value;
				Notify("Status");
			}
		}

		public HeaderStatusViewModel()
		{
			eventAgg = EventInstance.Instance.EventAggregator;
			eventAgg.GetEvent<SendData>().Subscribe(RecieveDataHandler);
		}

		private void RecieveDataHandler(string obj)
		{
			if (!string.IsNullOrEmpty(obj))
			{
				Status = obj;
			}
		}
	}
}
