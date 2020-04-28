/**
 * Classe du main: Programme de Gestion de Cloture du cas GSB
 * author : Marion-Castel
 * date : 28/04/2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;





namespace PPE_Mission2
{

    using System;
    using System.Timers;

    public class GestionClotureGSB
    {
        private static System.Timers.Timer aTimer;

        
        /**
         * Démarre l'application
         **/

        public static void Main()
        {
            SetTimer();

            
            aTimer.Stop();
            aTimer.Dispose();
        }

        /// <summary>
        /// Initialisation du Timer
        /// </summary>
        private static void SetTimer()
        { 
            aTimer = new System.Timers.Timer(10000); // Timer de 10 sec
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        /// <summary>
        /// Démarre le timer
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            ConnexionBDD lancement = new ConnexionBDD();

            lancement.clotureFiches(); // Lance la fonction de cloture de fiches
            lancement.validerLesFiches(); // Lance la fonction de validation des fiches
            

            Console.ReadLine();

        }

    }


}
