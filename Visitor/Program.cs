using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IElementVoitureVisitor printVisitor = new ElementVoiturePrintVisitor();
            IElementVoitureVisitor doVisitor = new ElementVoitureDoVisitor();

            Voiture voiture = new Voiture();

            printVisitor.VisitVoiture(voiture);
            doVisitor.VisitVoiture(voiture);

            Console.ReadKey();
        }
    }

    interface IElementVoiture
    {
        void Accept(IElementVoitureVisitor visitor);
    }

    class Roue : IElementVoiture
    {
        private string Name;

        public Roue(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void Accept(IElementVoitureVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Moteur : IElementVoiture
    {
        public void Accept(IElementVoitureVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
    class Carrosserie : IElementVoiture
    {

        public void Accept(IElementVoitureVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Voiture
    {
        IElementVoiture[] Elements;

        public Voiture()
        {
            this.Elements = new IElementVoiture[]
            {
                new Roue("avant gauche"),
                new Roue("avant droit"),
                new Roue("arrière gauche"),
                new Roue("arrière droit"),
                new Carrosserie(),
                new Moteur()
            };
        }

        public IElementVoiture[] GetElements()
        {
            return (IElementVoiture[])Elements.Clone(); 
        }
    }
    interface IElementVoitureVisitor
    {
        void Visit(Moteur moteur);
        void Visit(Roue roue);
        void Visit(Carrosserie carrosserie);
        void VisitVoiture(Voiture voiture);
    }

    class ElementVoiturePrintVisitor : IElementVoitureVisitor
    {
      
        public void Visit(Roue roue)
        {
            Console.WriteLine($"Visite de {roue.GetName()} roue");
        }

        public void Visit(Moteur moteur)
        {
            Console.WriteLine("Visite de moteur");
        }


        public void Visit(Carrosserie carrosserie)
        {
            Console.WriteLine("Visite de carrosserie");
        }

        public void VisitVoiture(Voiture voiture)
        {
            Console.WriteLine("\nVisite de la voiture");

            foreach (IElementVoiture element in voiture.GetElements())
            {
                element.Accept(this);
            }
            Console.WriteLine("=> Voiture visitée");
        }
    }
    
    class ElementVoitureDoVisitor : IElementVoitureVisitor
    {

        public void Visit(Roue roue)
        {
            Console.WriteLine($"Coup de pied sur roue {roue.GetName()}");
        }

        public void Visit(Moteur moteur)
        {
            Console.WriteLine("Démarrer mon moteur");
        }

        public void Visit(Carrosserie carrosserie)
        {
            Console.WriteLine("Déplacer ma carrosserie");
        }

        public void VisitVoiture(Voiture voiture)
        {
            Console.WriteLine("\nDémarrer ma voiture");

            foreach (IElementVoiture elementVoiture in voiture.GetElements())
            {
                elementVoiture.Accept(this);
            }
            Console.WriteLine("=> Voiture démarrée");
        }
    }
}
