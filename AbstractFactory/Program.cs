using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{

	class Program
	{
		static void Main(string[] args)
		{
			PCFactory pcFactory = new PCFactory("2 GB", "500 GB", "2,4 GHz");
			Computer pc = ComputerFactory.GetComputer(pcFactory);

			ServerFactory serverFactory = new ServerFactory("16 GB", "1 TB", "2,9 GHz");
			Computer server = ComputerFactory.GetComputer(serverFactory);
			
			PortableFactory portableFactory = new PortableFactory("1 GB", "0.5 TB", "3,6 GHz");
			Computer portable = ComputerFactory.GetComputer(portableFactory);

			Console.WriteLine("AbstractFactory PC Config :: " + pc.ToString());
			Console.WriteLine("AbstractFactory Server Config :: " + server.ToString());
			Console.WriteLine("AbstractFactory Portable Config :: " + portable.ToString());

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

    class Portable : Computer
    {
		private String Ram;
		private String Hdd;
		private String Cpu;

        public Portable(string ram, string hdd, string cpu)
        {
            Ram = ram;
            Hdd = hdd;
            Cpu = cpu;
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
    interface IComputerAbstractFactory
	{
		Computer CreateComputer();
	}

	class ServerFactory : IComputerAbstractFactory
	{
		private String Ram;
		private String Hdd;
		private String Cpu;

		public ServerFactory(String ram, String hdd, String cpu)
		{
			this.Ram = ram;
			this.Hdd = hdd;
			this.Cpu = cpu;
		}

		public Computer CreateComputer()
		{
			return new Server(Ram, Hdd, Cpu);
		}
	}

	class PCFactory : IComputerAbstractFactory
	{
		private String Ram;
		private String Hdd;
		private String Cpu;

		public PCFactory(String ram, String hdd, String cpu)
		{
			this.Ram = ram;
			this.Hdd = hdd;
			this.Cpu = cpu;
		}

		public Computer CreateComputer()
		{
			return new PC(Ram, Hdd, Cpu);
		}
	}

    class PortableFactory : IComputerAbstractFactory
    {
		private String Ram;
		private String Hdd;
		private String Cpu;

        public PortableFactory(string ram, string hdd, string cpu)
        {
            Ram = ram;
            Hdd = hdd;
            Cpu = cpu;
        }

        public Computer CreateComputer()
        {
			return new Portable(Ram, Hdd, Cpu);
        }
    }

    class ComputerFactory
	{
		public static Computer GetComputer(IComputerAbstractFactory factory)
		{
			return factory.CreateComputer();
		}
	}

}
