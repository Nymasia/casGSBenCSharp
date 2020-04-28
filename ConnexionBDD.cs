/**
 * Classe de connection avec la base de donnée: Programme de Gestion de Cloture du cas GSB
 * author : Marion-Castel
 * date : 28/04/2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;

namespace PPE_Mission2
{

    /**
     * Classe de connexion à la base de données du contexte GSB
     **/

    class ConnexionBDD
    {
        /// <summary>
        /// Fonction de connexion à la base de données Mysql
        /// </summary>
        /// 
        
        private MySqlConnection connexionBdd;

        /// <summary>
        /// Fonction qui initialise la connexion
        /// </summary>
        public void initConnexionBdd()
        {

            String connexionBdd = "Server= localhost; DATABASE=gsb_frais; UID=root; PASSWORD=";
            this.connexionBdd = new MySqlConnection(connexionBdd);
        }

        /**
         * Requêtes d'administration et d'exucution
         **/



        /// Fonction de requete d'administration vers la base de données gsb_frais
        public void reqAdministrateur(String req)
        {
            this.connexionBdd.Open();
            MySqlCommand cmd = this.connexionBdd.CreateCommand();
            cmd.CommandText = req;
            cmd.ExecuteNonQuery();
            this.connexionBdd.Close();

        }

        /// Fonction de requete qui execute les demandes vers la base de donnée
        /// return la lecture de la base de donnée MySQL par la variable MsqlDR
        /// 
        public MySqlDataReader reqDemandes(string req)
        {
            this.connexionBdd.Open();
            MySqlCommand cmd = new MySqlCommand(req, connexionBdd);
            MySqlDataReader MsqlDR = cmd.ExecuteReader();
            cmd.Dispose();
            this.connexionBdd.Close();
            return MsqlDR;

        }

        /// <summary>
        /// Fonction cloture des fiches quand elles sont comprises entre le 1 et le 10 du mois
        /// </summary>
        public void clotureFiches()
        {

            string mois = "201710";
            string req = "SELECT `idvisiteur` FROM `fichefrais` where `mois` = '" + mois + "';";

            Dictionary<int, RecupFichesMois> fichesMois = new Dictionary<int, RecupFichesMois>();

            if (GestionsDates.entre(1, 10))
            {

                connexionBdd.Open();

                int i = 0;
                string idEtat = "CL";
                MySqlCommand cmd = new MySqlCommand(req, connexionBdd);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string idVisiteur = dataReader["idvisiteur"] + "";
                    RecupFichesMois fiche = new RecupFichesMois(idVisiteur, mois, idEtat);
                    fichesMois.Add(i, fiche);
                    i++;
                }
            }

            connexionBdd.Close();

            for (int i = 0; i < fichesMois.Count; i++)
            {

                req = "UPDATE fichefrais" +
                        " SET idetat='CL'" +
                        " WHERE idvisiteur='" + fichesMois[i].getIdVisiteur() + "'" +
                        " AND mois = '" + fichesMois[i].getMois() + "'";

                Console.WriteLine(req);


                connexionBdd.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = req;
                cmd.Connection = connexionBdd;
                cmd.ExecuteNonQuery();
                connexionBdd.Close();
            }
        }


        /// <summary>
        /// Fonction validation des fiches comprises entre le 20 et le 31 du mois
        /// </summary>
        public void validerLesFiches()
        {

            string mois = "03";
            string req = "SELECT `idvisiteur` " +
                         "FROM `fichefrais` " +
                         "WHERE `mois` = '" + mois +
                         "' AND idetat = 'CL';";

            Dictionary<int, RecupFichesMois> fichesMois = new Dictionary<int, RecupFichesMois>();

            if (GestionsDates.entre(20, 31))
            {


                connexionBdd.Open();

                int i = 0;
                string idEtat = "VA";
                MySqlCommand cmd = new MySqlCommand(req, connexionBdd);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    string idVisiteur = dataReader["idvisiteur"] + "";
                    RecupFichesMois uneFiche = new RecupFichesMois(idVisiteur, mois, idEtat);
                    fichesMois.Add(i, uneFiche);
                    i++;
                }
            }

            connexionBdd.Close();

            for (int i = 0; i < fichesMois.Count; i++)
            {
                req = "UPDATE fichefrais" +
                        " SET idetat='VA'" +
                        " WHERE idvisiteur='" + fichesMois[i].getIdVisiteur() + "'" +
                            " AND mois = '" + fichesMois[i].getMois() + "'" +
                            " AND idetat = 'CL'";
                Console.WriteLine(req);

                connexionBdd.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = req;

                cmd.Connection = connexionBdd;

                cmd.ExecuteNonQuery();
                
                connexionBdd.Close();


            }
        }

    }
}



        
