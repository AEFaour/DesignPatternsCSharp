using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDesignPatterns
{
	class ConnectionDataBase
	{
		private static ConnectionDataBase instance = null;
		private static readonly string dbURL = "SERVER=127.0.0.1; DATABASE=doranco; UID=root; PWD=root";
		private static MySqlConnection connection = null;

		private ConnectionDataBase()
		{
		}

		public static ConnectionDataBase GetInstance()
        {
			Console.WriteLine("Récupération de l'instance unique de la classe");
             if(instance == null)
            {
				instance = new ConnectionDataBase();
			}
			
			return instance;
		}

		public MySqlConnection GetConnection()
		{	
			try
			{
				connection = new MySqlConnection(dbURL);
				connection.Open();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erreur lors de la récupération de la connection à la BDD");
				Console.WriteLine(ex.Message);
			}
			return connection;
		}
	}
}
