using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Eleve Eleve = new Eleve();

            new NotesObserver(Eleve);

            Eleve.AjouterNote(15.0f);
            Console.WriteLine($"La moyenne de l'eleve = {Eleve.GetMoyenne()}");
            Eleve.AjouterNote(5.0f);
            Console.WriteLine($"La moyenne de l'eleve = {Eleve.GetMoyenne()}");
            Eleve.AjouterNote(13.0f);
            Console.WriteLine($"La moyenne de l'eleve = {Eleve.GetMoyenne()}");

            Console.ReadKey();
        }
    }

    public abstract class Observer
    {
        public Eleve Eleve;
        public abstract void Update();
    }

    public class Eleve
    {
        private IList<Observer> Observers;
        private IList<float> Notes;
        private float Moyenne;

        public Eleve()
        {
            this.Observers = new List<Observer>();
            this.Notes = new List<float>();
        }

        public void AjouterNote(float note)
        {
            Notes.Add(note);
            NotifyAllObservers();
        }

        public float GetMoyenne()
        {
            return Moyenne;
        }

        public void SetMoyenne(float moyenne)
        {
            this.Moyenne = moyenne;
        }

        public IList<float> GetNotes()
        {
            return Notes;
        }

        public void AttachObserver(Observer observer)
        {
            Observers.Add(observer);
        }

        public void NotifyAllObservers()
        {
            foreach (var Observer in Observers)
            {
                Observer.Update();
            }
        }

    }


    class NotesObserver : Observer
    {
        public NotesObserver(Eleve Eleve)
        {
            this.Eleve = Eleve;
            Eleve.AttachObserver(this);
        }
        public override void Update()
        {

            float resultatFinal = 0;


            foreach (var note in Eleve.GetNotes())
            {
                resultatFinal += note;
            }

            resultatFinal /= Eleve.GetNotes().Count();

            Eleve.SetMoyenne(resultatFinal);
        }
    }
}
