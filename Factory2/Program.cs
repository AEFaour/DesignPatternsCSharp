using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory2
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
		public abstract string GetRAM();
		public abstract string GetHDD();
		public abstract string GetCPU();



		public override string ToString()
		{
			return "La taille de la RAM = " + this.GetRAM() + ", la taille du Disque Dur = " + this.GetHDD() + "et la cadence du CPU = " + this.GetCPU();
		}
	}

	class Server : Computer
	{
		private String Ram;
		private String Hdd;
		private String Cpu;

		public Server(String ram, String hdd, String cpu)
		{
			this.Ram = ram;
			this.Hdd = hdd;
			this.Cpu = cpu;
		}

		public override String GetRAM()
		{
			return this.Ram;
		}

		public override String GetHDD()
		{
			return this.Hdd;
		}

		public override String GetCPU()
		{
			return this.Cpu;
		}
	}

	class PC : Computer
	{
		private String Ram;
		private String Hdd;
		private String Cpu;

		public PC(String ram, String hdd, String cpu)
		{
			this.Ram = ram;
			this.Hdd = hdd;
			this.Cpu = cpu;
		}

		public override String GetRAM()
		{
			return this.Ram;
		}

		public override String GetHDD()
		{
			return this.Hdd;
		}

		public override String GetCPU()
		{
			return this.Cpu;
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
