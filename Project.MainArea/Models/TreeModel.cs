using Project.CommonInfra.BaseClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MainArea.Models
{
	public class TreeModel:BindableBase
	{
		public TreeModel()
		{
			ChildTreeModel = new ObservableCollection<TreeModel>();
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value;
				Notify("Name");
			}
		}

		private ObservableCollection<TreeModel> childTreeModel;

		public ObservableCollection<TreeModel> ChildTreeModel
		{
			get { return childTreeModel; }
			set { childTreeModel = value;
				Notify("ChildTreeModel");
			}
		}

	}
}
