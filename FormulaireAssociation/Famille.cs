using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaireAssociation
{
    class Famille
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string nbAdulte { get; set; }
        public string nbEnfant { get; set; }
        public string Statut { get; set; }
        public string Legumes { get; set; }
        public string Fruits { get; set; }
        public string Viennoiseries { get; set; }
        public string QLegume { get; set; }
        public string QFruit { get; set; }
        public string QViennoiserie { get; set; }

        // Méthode de collection des familles

        public List<Famille> AjouterFamille()
        {
            List<Famille> familles = new List<Famille>();
            familles.Add(new Famille()
            {
                Nom = "Boubala",
                Prenom = "Steevy",
                Telephone = "07 71 94 43 61",
                nbAdulte = "2",
                nbEnfant = "3",
                Statut = "Ancien",
                Legumes = "Tomate",
                Fruits = "Orange",
                Viennoiseries = "Croissant",
                QLegume = "2",
                QFruit = "1",
                QViennoiserie = "5"
            });

            familles.Add(new Famille()
            {
                Nom = "Dupont",
                Prenom = "Alex",
                Telephone = "07 55 94 43 12",
                nbEnfant = "2",
                Statut = "Ancien",
                Legumes = "Random",
                Fruits = "Orange",
                Viennoiseries = "Tenis",
                QLegume = "2",
                QFruit = "1",
                QViennoiserie = "5"
            });

            return familles;
        }

    }

}
