using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory3
{
    class Program
    {
        static void Main(string[] args)
        {


            Computer pc = ComputerFactory.GetComputer(new PC("2 GB", "500 GB", "2,4 GHz"));

            Computer server = ComputerFactory.GetComputer(new Server("16 GB", "1 TB", "2,9 GHz"));


            Console.WriteLine("Factory PC Config :: " + pc);
            Console.WriteLine("Factory Server Config :: " + server);


            Console.ReadKey();
        }
    }

    abstract class Computer
    {
        public string Type;
        public string Ram;
        public string Hdd;
        public string Cpu;

        public abstract string Infos();


        public override string ToString()
        {
            return "Type de l'ordinateur = " + Type +
                   ", la taille de la RAM = " + Ram + ", la taille du Disque Dur = "
                   + Hdd + "et la cadence du CPU = " + Cpu + " => " + Infos();

        }
    }

    class Server : Computer
    {
       
        public Server(string ram, string hdd, string cpu)
        {
            Type = "Serveur";
            Ram = ram;
            Hdd = hdd;
            Cpu = cpu;
        }


        public override string Infos()
        {

            return "Ceci est un " + Type;
        }
    }

    class PC : Computer
    {
       

        public PC(string ram, string hdd, string cpu)
        {
            Type = "PC";
            Ram = ram;
            Hdd = hdd;
            Cpu = cpu;
        }

        public override string Infos()
        {
            return "Ceci est un " + Type;
        }
    }

    class ComputerFactory
    {

        public static Computer GetComputer(Computer computer)
        {

            return computer;
        }

    }

}
