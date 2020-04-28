/**
 * Classe abstraite de la gestion des dates: Programme de Gestion de Cloture du cas GSB
 * author : Marion-Castel
 * date : 28/04/2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_Mission2
{
    /**
     * Classe abstraite qui permet de gérer les dates 
     **/

    public abstract class GestionsDates
    {

        /// <summary>
        ///  /// Fonction permetant d'obtenir le mois actuel sous forme d'une chaine de deux chiffres et 
        /// d'aider à effectuer les calculs pour les autres fonctions
        /// </summary>
        /// <param name="m"></param>
        /// <param name="val"></param>
        /// <returns> String mois </returns>
        private static String moisActuel (DateTime m, int val)
        {
            //Déclarations
            m = m.AddMonths(val); // Récupère en chiffre le mois actuel
            String mois = m.ToString("MM"); // Ecrit le mois actuel avec deux chiffres


            return mois;
            
        }

        /// <summary>
        /// Permet de récupérer dans la fonction la date actuelle dans la fonction du mois précédent
        /// </summary>
        /// <returns></returns>
        public static String getMoisPrecedent()
        {
            return getMoisPrecedent(DateTime.Today);
        }

        /// <summary>
        /// Fonction surcharge de la précédente qui permet de récupérer le mois précédent avec deux chiffres
        /// </summary>
        /// <param name="m"></param>
        /// <returns> String mois - 1</returns>
        public static String getMoisPrecedent(DateTime m)
        {
            return moisActuel(m, -1);
        }

        /// <summary>
        /// Permet de récupérer dans la fonction la date actuelle dans la fonction du mois suivant
        /// </summary>
        /// <returns></returns>
        public static String getMoisSuivant()
        {
            return getMoisSuivant(DateTime.Today);
        }


        /// <summary>
        /// Fonction surcharge de la précédente qui permet de récupérer le mois suivant avec deux chiffres
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static String getMoisSuivant(DateTime m)
        {
            return moisActuel(m, +1);
        }


        /// <summary>
        /// Fonction qui retourne vrai en fonction de la même fonction surchargée
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <returns></returns>
        public static Boolean entre(int jour1, int jour2)
        {
            return entre(jour1, jour2, DateTime.Today);
        }

        /// <summary>
        /// Fonction qui retourne vrai si le jour est bien compris entre jour1 et jour2
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static Boolean entre (int jour1, int jour2, DateTime j)
        {

            // Déclarations
            int jActuel = j.Day; // Récupère le jour actuel

            // Si le jour est compris entre jour1 et jour 2 alors entre() retourne vrai 
            // Sinon elle retourne faux.

            if (jActuel >= jour1 && jActuel <= jour2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Retourne la chaine de caractère composée de l'année et du mois précédent la date en cours 
        /// </summary>
        /// <param name="mois">Le numéro du mois précédent sous forme de chaine de caractère</param>
        /// <returns>annee + mois en String</returns>
        public static string moisannee(string mois)
        {
            int annee = DateTime.Today.Year;
            if (mois == "12")
            {
                annee = annee - 1;
            }
            return annee + mois;
        }

        
    }
    
}
