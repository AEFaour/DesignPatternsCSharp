using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {

            Voiture vCorsa = new Corsa();
            Console.WriteLine($"Voiture : {vCorsa}.");

            Voiture vC2 = new C2();
            Console.WriteLine($"Voiture : {vC2}.");

            Voiture vCorsaReg = new Regulateur(vCorsa);
            Console.WriteLine($"Voiture : {vCorsaReg}.");

            Voiture vC2GPS = new Regulateur(vC2);
            Console.WriteLine($"Voiture : {vC2GPS}.");

            Voiture vCorsa1 = new Corsa();
            Voiture vCorsa2 = new GPS(vCorsa1);
            Voiture vCorsa3 = new Regulateur(vCorsa2);
            Voiture vCorsa4 = new ToitOuvrant(vCorsa3);
            Console.WriteLine($"Voiture  Corsa => {vCorsa4}.");

            Voiture vCitroen1 = new C2();
            Voiture vCitroen2 = new GPS(vCitroen1);
            Voiture vCitroen3 = new Regulateur(vCitroen2);
            Voiture vCitroen4 = new ToitOuvrant(vCitroen3);
            Console.WriteLine($"Voiture C2 => {vCitroen4 }.");

            Console.ReadKey();
        }
    }
    class Voiture
    {
        private string Libelle;
        private int Prix;
        private int Poids;

        public string GetLibelle()
        {
            return Libelle;
        }

        public int GetPrix()
        {
            return Prix;
        }

        public int GetPoids()
        {
            return Poids;
        }

        protected void SetLibelle(string libelle)
        {
            this.Libelle = libelle;
        }

        protected void SetPrix(int prix)
        {
            this.Prix = prix;
        }

        protected void SetPoids(int poids)
        {
            this.Poids = poids;
        }

        public override string ToString()
        {
            return "La voiture est : " + this.Libelle + ", le prix de la voiture : "
                + this.Prix + " et le poids de la voiture : " + this.Poids + ".";
        }
    }

    class Corsa : Voiture
    {
        public Corsa()
        {
            SetLibelle("Corsa");
            SetPrix(7100);
            SetPoids(1800);
        }
    }

    class C2 : Voiture
    {
        public C2()
        {
            SetLibelle("C2");
            SetPrix(3500);
            SetPoids(1100);
        }
    }

    abstract class DecorateurVoiture : Voiture
    {

        protected Voiture Voiture;

        public abstract new string GetLibelle();
        public abstract new int GetPrix();
        public abstract new int GetPoids();
    }

    class ToitOuvrant : DecorateurVoiture
    {
        private string Libelle = " Toit Ouvrant";
        private int Prix = 1500 ;
        private int Poids = 10;

        public ToitOuvrant(Voiture v)
        {
            Voiture = v;

            if (v.GetType() != this.GetType())
            {
                SetLibelle(GetLibelle());
                SetPrix(GetPrix());
                SetPoids(GetPoids());
            }
        }

        public override string GetLibelle()
        {
            return Voiture.GetLibelle() + this.Libelle;
        }

        public override int GetPrix()
        {
            return Voiture.GetPrix() + this.Prix;
        }

        public override int GetPoids()
        {
            return Voiture.GetPoids() + this.Poids;
        }
    }
    class GPS : DecorateurVoiture
    {
        private string Libelle = " GPS";
        private int Prix = 700;
        private int Poids = 5;

        public GPS(Voiture v)
        {
            Voiture = v;

            if (v.GetType() != this.GetType())
            {
                SetLibelle(GetLibelle());
                SetPrix(GetPrix());
                SetPoids(GetPoids());
            }
        }


        public override string GetLibelle()
        {
            return Voiture.GetLibelle() + this.Libelle;
        }

        public override int GetPoids()
        {
            return Voiture.GetPrix() + this.Prix;
        }

        public override int GetPrix()
        {
            return Voiture.GetPoids() + this.Poids;
        }



    }
    class Regulateur : DecorateurVoiture
    {
        private string Libelle = " Regulateur";
        private int Prix = 400;
        private int Poids = 3;

        public Regulateur(Voiture v)
        {
            Voiture = v;

            if(v.GetType() != this.GetType())
            {
                SetLibelle(GetLibelle());
                SetPrix(GetPrix());
                SetPoids(GetPoids());
            }
        }


        public override string GetLibelle()
        {
            return Voiture.GetLibelle() + this.Libelle;
        }

        public override int GetPrix()
        {
            return Voiture.GetPrix() + this.Prix;
        }

        public override int GetPoids()
        {
            return Voiture.GetPoids() + this.Poids;
        }
    }
}
