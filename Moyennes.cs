using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMoyennes
{

    //class tableau stockage de mes moyennes
    class moyennesClasse
    {
        public static string[] matieresc = new string[10];
        public static double[] moyennec = new double[10];
        public static void Initialize()
        {
            matieresc = new string[10];
            moyennec = new double[10];
        }
    }


    //def de classe données + moyennes associé
    class Classe
    {
        public string nomClasse; 
        public List<Eleve> eleves = new List<Eleve>();
        public List<string> matieres = new List<string>();

        // ajout du nom de la classe
        public Classe(string classeNom)
        {
            nomClasse = classeNom;
        }


        // ajout des eleves de la classe
        public void ajouterEleve (string prenom, string nom)
        {
            Eleve eleveClasse = new Eleve(prenom, nom);
            eleves.Add(eleveClasse);
        }

        // ajout des Matieres de la classe
        public void ajouterMatiere (string matiere)
        {
            matieres.Add(matiere);
        }

        //calcul en de la moyenne de la classe par matiere
        public double moyenneMatiere (int m)
        {
            double moyenneMC = 0;
            for (int i = 0; i < matieres.Count; i++)
            {
                double sommeMoyenneE = 0;
                int counter = 0;
                for (int j = 0; j < eleves.Count; j++)
                {
                    sommeMoyenneE += eleves[j].moyenneMatiere(m);
                    counter++;
                }
                moyenneMC += sommeMoyenneE / counter;
                moyennesClasse.matieresc[i] = matieres[i];
                moyennesClasse.moyennec[i] = Math.Round(moyenneMC, 2);
            }
            return Math.Round(moyenneMC, 2);
        }

        //calcul de la moyenne generale de la classe
        public double moyenneGeneral ()
        {
            double mGC = 0;
            double sommemoyenneMC = 0;
            int counter = 0;
            for (int i = 0;i < matieres.Count; i++)
            {
                if (moyennesClasse.moyennec[i] > 0)
                {
                    sommemoyenneMC += moyennesClasse.moyennec[i];
                    counter++;
                }
            }
            mGC += sommemoyenneMC / counter;
            return Math.Round(mGC, 2);

        }
    }

    //definition des eleves et calcul de leur moyenne
    class Eleve
    {
        // declarations prenom - notes
        public string prenom {  get;}
        public string nom { get;}
        public List<Note> notes { get;}

        // Array pour stocker les moyennes d'un eleves
        public double[] moyennesEleve;


        public Eleve (string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            notes = new List<Note>();

            moyennesEleve = new double[10];
        }

        public void AjouterNote(Note note)
        {
            notes.Add(note);
        }

        public double moyenneMatiere(int m)
        {
            double moyenneME = 0;
            double sommeNM = 0;
            int counter = 0;
            for(int i = 0; i < notes.Count; i++)
            {
                if (notes[i].matiere == m)
                {
                    sommeNM += notes[i].note;
                    counter++;
                }
            }
            moyenneME += sommeNM / counter;
            moyennesEleve[m] = Math.Round(moyenneME, 2);
            return Math.Round(moyenneME, 2);
        }

        public double moyenneGeneral()
        {
            double moyenneGE = 0;
            double sommeGE = 0;
            int counter = 0;
            for (int i = 0;i < moyennesEleve.Length; i++ )
            {
                if (moyennesEleve[i] > 0)
                { 
                    sommeGE += moyennesEleve[i];
                    counter++;
                }
            }
            moyenneGE += sommeGE / counter;
            return Math.Round(moyenneGE, 2);
        }
    }
}
