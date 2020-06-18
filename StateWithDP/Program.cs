using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateWithDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video();
            video.SetState(new VideoEnLecture());
            video.Action();
            video.SetState(new VideoEnPause());
            video.Action();
            video.SetState(new RetourAuDebut());
            video.Action();
            video.SetState(new SeRendreAuMilieu());
            video.Action();

            Console.ReadKey();
        }
    }
    class Video
    {
        private IEtatVideo EtatVideo;

        public void SetState(IEtatVideo newEtat)
        {
            this.EtatVideo = newEtat;
        }

        public void Action()
        {
            this.EtatVideo.Action();
        }
    }

    public interface IEtatVideo
    {
        void Action();

    }

    public class VideoEnLecture : IEtatVideo
    {
        public void Action()
        {
            Console.WriteLine("La vidéo est en lecture");
        }
    }
    public class VideoEnPause : IEtatVideo
    {
        public void Action()
        {
            Console.WriteLine("La vidéo est en pause");
        }
    }
    public class RetourAuDebut : IEtatVideo
    {
        public void Action()
        {
            Console.WriteLine("La vidéo recommence depuis le début");
        }
    }
    public class SeRendreAuMilieu : IEtatVideo
    {
        public void Action()
        {
            Console.WriteLine("Se Rendre Au Milieu De La Vidéo");
        }
    }
}
