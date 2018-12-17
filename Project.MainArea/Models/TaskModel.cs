using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MainArea.Models
{
	public class TaskModel
	{
		public string Header { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public TaskModel()
		{
			Date = DateTime.Now;
		}
	}
}
