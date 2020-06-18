using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {

            Remorque maRemorque = new Remorque(11);
            Console.WriteLine($"Le poids de ma remorque est : {maRemorque.getPoids()} tonnes");

            Tracteur monTracteur = new Tracteur(8);
            Console.WriteLine($"Le poids de mon tracteur est : {monTracteur.getPoids()} tonnes");

            Charge maCharge = new Charge(5);
            Console.WriteLine($"Le poids de ma charge est : {maCharge.getPoids()} tonnes");

            CamionComposite semiRemorque = new CamionComposite();
            semiRemorque.Ajouter(maRemorque);
            semiRemorque.Ajouter(monTracteur);
            semiRemorque.Ajouter(maCharge);

            Console.WriteLine($"Le poids de semi-remorque est : {semiRemorque.getPoids()} tonnes");

            Console.ReadLine();
        }
    }

    public interface IComposant
    {
         int getPoids();
    }

    public class Remorque : IComposant
    {
        private int poids;

        public Remorque(int poids)
        {
            this.poids = poids;
        }

        public int getPoids()
        {
            return this.poids;
        }
    }
    

    public class Tracteur : IComposant
    {
        private int poids;

        public Tracteur(int poids)
        {
            this.poids = poids;
        }

        public int getPoids()
        {
            return this.poids;
        }
    }

    public class Charge : IComposant
    {
        private int poids;

        public Charge(int poids)
        {
            this.poids = poids;
        }

        public int getPoids()
        {
            return this.poids;
        }
    }



    public class CamionComposite : IComposant
    {
        private IList<IComposant> Children;


        public CamionComposite()
        {
            this.Children = new List<IComposant>();
        }

        

        public void Ajouter(IComposant composant)
        {
            this.Children.Add(composant);
        }
        
        public void Retirer(IComposant composant)
        {
            this.Children.Add(composant);
        }

        public int getPoids()
        {
            int poids = 0;

            foreach (IComposant child in Children)
            {
                poids += child.getPoids();
            }

            return poids;
        }
    }
}
