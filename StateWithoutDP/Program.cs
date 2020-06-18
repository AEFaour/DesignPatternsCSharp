using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video();

            video.SetEtat("PLAY");
            video.Action();

            video.SetEtat("PAUSE");
            video.Action();

            video.SetEtat("DEBUT");
            video.Action();

            Console.ReadKey();
        }
    }
    class Video
    {
        private string Etat = "";
        public void SetEtat(string etat)
        {
            this.Etat = etat;
        }

        public void Action()
        {
            if (string.Equals(Etat, "PLAY", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("La vidéo est en lecture");
            }
            else if (string.Equals(Etat, "PAUSE", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("La vidéo est en pause");
            }else if (string.Equals(Etat, "DEBUT", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("La vidéo recommence depuis le début");
            }
        }
    }
}
