using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
   

            MySqlConnection connection1 = ConnectionDataBase.GetInstance().GetConnection();

            if (connection1 != null)
            {
                Console.WriteLine($"instance : {ConnectionDataBase.GetInstance().GetHashCode()}");
                Console.WriteLine("Connexion 1 récupéré avec succès");
                Console.WriteLine($" -> Code : {connection1.GetHashCode()}");
            }
            else
            {
                Console.WriteLine("Aucune connexion récupéré ");
            }

            MySqlConnection connection2 = ConnectionDataBase.GetInstance().GetConnection();

            if (connection2 != null)
            {
                Console.WriteLine($"instance : {ConnectionDataBase.GetInstance().GetHashCode()}");
                Console.WriteLine("Connexion 2 récupéré avec succès");
                Console.WriteLine($" -> Code : {connection2.GetHashCode()}");
            }
            else
            {
                Console.WriteLine("Aucune connexion récupéré ");
            }

            Console.ReadKey();

        }
    }
}
