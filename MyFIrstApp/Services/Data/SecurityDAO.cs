using MyFIrstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFIrstApp.Services.Data
{
	//search SqlCommand.Parameters Property at Microsoft's website for help
	public class SecurityDAO
	{
		//connect to a database
		//if there is a backslash in a string, using the @ symbol will treat the string as literal
		string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		internal bool FindByUser(UserModel user)
		{
			//start by assuming that nothing is found in this query
			bool success = false;

			//write the SQL expression (this line prevents SQL injection)
			string queryString = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @Password";

			//create and open the connection to the database inside the using block
			//this ensures that all resources are closed properly when the query is done.
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//create the command and parameter objects
				SqlCommand command = new SqlCommand(queryString, connection);

				//associating @Username with user.username
				command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
				command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

				//open the database and run the command
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					if (reader.HasRows)
					{
						success = true;
					}
					else
					{
						success = false;
					}
					reader.Close();
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return success;
		}
	}
}