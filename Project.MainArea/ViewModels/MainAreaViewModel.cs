using Prism.Events;
using Project.CommonInfra.BaseClass;
using Project.CommonInfra.Events;
using Project.DAL;
using Project.MainArea.Interfaces;
using Project.MainArea.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MainArea.ViewModels
{

	public class MainAreaViewModel:BindableBase,IMainAreaViewModel
	{
		private ObservableCollection<TreeModel> treeSource;
		public ObservableCollection<TreeModel> TreeSource
		{
			get { return treeSource; }
			set { treeSource = value;
				Notify("TreeSource");
			}
		}

		private ObservableCollection<TaskModel> taskSource;

		public ObservableCollection<TaskModel> TaskSource
		{
			get { return taskSource; }
			set { taskSource = value;
				Notify("TaskSource");
			}
		}


		private TreeModel selectedTreeItem;
		public TreeModel SelectedTreeItem
		{
			get { return selectedTreeItem; }
			set { selectedTreeItem = value;
				Notify("SelectedTreeItem");
				MainAreaVisiblity = true;
			}
		}

		private bool mainAreaVisiblity;
		public bool MainAreaVisiblity
		{
			get { return mainAreaVisiblity; }
			set { mainAreaVisiblity = value;
				Notify("MainAreaVisiblity");
			}
		}

		IEventAggregator eventAgg { get; set; }
		public MainAreaViewModel()
		{
			eventAgg = EventInstance.Instance.EventAggregator;
			SqlHelper.InitDB();
			bool b = SqlHelper.IsConnectionOpen();
			bool b1 = SqlHelper.IsConnectionOpen();
			eventAgg.GetEvent<SendData>().Publish("bhagwat");
			TreeSource = new ObservableCollection<TreeModel>();
			TaskSource = new ObservableCollection<TaskModel>();
			SelectedTreeItem = new TreeModel();
			FetchData();
			WhereClause(3);
			InitializeTreeView();
			InitializeTaskSource();
			MainAreaVisiblity = false;
		}

		private void InitializeTaskSource()
		{
			TaskSource.Add(new TaskModel() { Header = "task1", Description = "the quick", Date = DateTime.Now });
			TaskSource.Add(new TaskModel() { Header = "task2", Description = "brown fox quick", Date = DateTime.Now });
			TaskSource.Add(new TaskModel() { Header = "task3", Description = "jumps", Date = DateTime.Now });
			TaskSource.Add(new TaskModel() { Header = "task4", Description = "right over", Date = DateTime.Now });
			TaskSource.Add(new TaskModel() { Header = "task5", Description = "the lazy dogs", Date = DateTime.Now });
		}

		private void InitializeTreeView()
		{
			TreeModel tree1 = new TreeModel();
			tree1.ChildTreeModel.Add(new TreeModel() { Name = "Child1" });
			TreeSource.Add(new TreeModel() { Name = "ABC" ,ChildTreeModel=tree1.ChildTreeModel});

			TreeModel tree2 = new TreeModel();
			tree2.ChildTreeModel.Add(new TreeModel() { Name = "Child2" });
			TreeSource.Add(new TreeModel() { Name = "PQR" , ChildTreeModel=tree2.ChildTreeModel});

			TreeModel tree3 = new TreeModel();
			tree3.ChildTreeModel.Add(new TreeModel() { Name = "Child3" });
			TreeSource.Add(new TreeModel() { Name = "XYZ",ChildTreeModel=tree3.ChildTreeModel });
		}

		private void WhereClause(int eid)
		{
			using (SqlCommand command = new SqlCommand("select * from EmployeeInfo where Id="+eid, SqlHelper.GetConnection()))
			{
				command.CommandType = System.Data.CommandType.Text;
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						int id = (int)reader["Id"];
						string name = (string)reader["Name"];
						int age = (int)reader["Age"];
					}
				}
			}
		}

		private void FetchData()
		{
			using(SqlCommand command = new SqlCommand("select * from EmployeeInfo", SqlHelper.GetConnection()))
			{
				command.CommandType = System.Data.CommandType.Text;
				using(SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						int id = (int)reader["Id"];
						string name = (string)reader["Name"];
						int age = (int)reader["Age"];
					}
				}
			}
		}
	}
}
