using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Article article1 = new Article("Livre : 'Tout savoir sur le pattern Strategy'", 25);
            Article article2 = new Article("Piano steinway & sons d274", 155690);

            //paiement par Paypal

            article1.Payer(new PaypalStrategy("idExemple", "passwordExemple"));

            //paiement par carte de crédit
            article2.Payer(new CarteDeCreditStrategy("1234567890123456", "786", "12/15"));

            Console.ReadKey();
        }
    }

    interface IPaiementStrategy
    {
        void Payer(float montant);
    }

    class PaypalStrategy : IPaiementStrategy
    {
        private string Email;
        private string Password;

        public PaypalStrategy(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public void Payer(float montant)
        {
            char euro = Convert.ToChar(8364);

            Console.WriteLine($"Le montant de {montant} euros a été payé par Paypal");
        }
    }

    class CarteDeCreditStrategy : IPaiementStrategy
    {
        private string NumeroCarte;
        private string Cryptogramme;
        private string DateExpiration;

        public CarteDeCreditStrategy(string numeroCarte, string cryptogramme, string dateExpiration)
        {
            this.NumeroCarte = numeroCarte;
            this.Cryptogramme = cryptogramme;
            this.DateExpiration = dateExpiration;
        }

        public void Payer(float montant)
        {
            Console.WriteLine($"Le montant de {montant} euros a été payé par Carte de Credit");
        }
    }

    class Article
    {
        private string Nom;
        private float Prix;

        public Article(string nom, float prix)
        {
            this.Nom = nom;
            this.Prix = prix;
        }

        public string GetNom()
        {
            return this.Nom;
        }
        
        public float GetPrix()
        {
            return this.Prix;
        }

        public void Payer(IPaiementStrategy paiementStrategy)
        {
            float montant = this.GetPrix();

            paiementStrategy.Payer(montant);
        }
    }
}
