﻿/**
 * Classe qui récupère les ficges du mois:  Programme de Gestion de Cloture du cas GSB
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
    internal class RecupFichesMois
    {
        private string idVisiteur;
        private string mois;
        private string idEtat;

        /// <summary>
        /// Mutateur du nouvel état de la fiche
        /// </summary>
        /// <param name="newIdEtat">Le nouvel état de la fiche</param>
        public void setIdEtat(string newIdEtat)
        {
            if (newIdEtat == "CL" || newIdEtat == "CR" || newIdEtat == "RB" || newIdEtat == "VA")
            {
                this.idEtat = newIdEtat;
            }
        }

        /// <summary>
        /// Constructeur par paramètres
        /// </summary>
        /// <param name="idVisiteur">L'identifiant de l'utilisateur</param>
        /// <param name="mois">Le mois de la fiche</param>
        /// <param name="idEtat">L'état de la fiche</param>
        public RecupFichesMois(string idVisiteur, string mois, string idEtat)
        {
            this.idVisiteur = idVisiteur;
            this.mois = mois;
            this.setIdEtat(idEtat);
        }

        /// <summary>
        /// Accesseur pour l'identifiant de l'utilisateur
        /// </summary>
        /// <returns>L'identifiant de l'utilisateur</returns>
        public string getIdVisiteur() { return this.idVisiteur; }

        /// <summary>
        /// Accesseur pour le mois de la fiche
        /// </summary>
        /// <returns>Le mois de la fiche</returns>
        public string getMois() { return this.mois; }
    }
}
