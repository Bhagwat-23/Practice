using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
	public static class SqlHelper
	{
		private static string connString = ConfigurationManager.AppSettings["ConnectionString"];
		private static SqlConnection sqlConnection;
		public static void InitDB()
		{
			sqlConnection = new SqlConnection(connString);
			if(sqlConnection.State!= System.Data.ConnectionState.Open)
			{
				sqlConnection.Open();
			}
		}

		public static bool IsConnectionOpen()
		{
			if (sqlConnection.State == System.Data.ConnectionState.Open)
				return true;
			return false;
		}

		public static SqlConnection GetConnection()
		{
			return sqlConnection;
		}
	}
}
