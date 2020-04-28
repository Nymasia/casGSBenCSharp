using System;
using System.IO;
using System.Timers;
using System.Diagnostics;

namespace ServicesWindosAppGSB
{
    internal class MainManager
    {
        private Timer monTimer;

        public MainManager()
        {
            // Création d'un objet Timer
            monTimer = new Timer();
            monTimer.Interval = 60000;  // 60 000 ms = 60 s = 1 min        
            monTimer.AutoReset = true;
            monTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.monTimer_Elapsed);
            monTimer.Enabled = true;
        }

        private void monTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            monTimer.Enabled = false;

            Process P = Process.Start(@"C:\Users\NYMASIA\Desktop\BT SIO SLAM\BTS SIO SLAM 
                                        2ème année CNED\PPE\Mission2\PPE-Mission2\PPE-Mission2\
                                        bin\Debug", null);

            monTimer.Enabled = true;
        }

    }
}