using Prism.Events;
using Project.CommonInfra.Events;
using Project.DAL;
using Project.MainArea.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MainArea.ViewModels
{

	public class MainAreaViewModel:IMainAreaViewModel
	{
		IEventAggregator eventAgg { get; set; }
		public MainAreaViewModel()
		{
			eventAgg = EventInstance.Instance.EventAggregator;
			SqlHelper.InitDB();
			bool b = SqlHelper.IsConnectionOpen();
			bool b1 = SqlHelper.IsConnectionOpen();
			eventAgg.GetEvent<SendData>().Publish("bhagwat");

			FetchData();
			WhereClause(3);
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
