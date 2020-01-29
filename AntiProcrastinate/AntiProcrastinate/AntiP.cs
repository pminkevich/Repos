using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiProcrastinate.Admin;
using System.Timers;

namespace AntiProcrastinate
{
    class AntiP
    {
      
        private string State;
        private Control Controller;
        private int OcioTime;
        private int APTime;
        private Timer TimeStart;
        UserForm FrmUser;

        public AntiP()
        {
            Controller = new Control();
            TimeStart = new Timer();
            FrmUser = new UserForm();
            Controller.EventState += StateMonitor;
            Controller.State();
            
        }

        
        private void StateMonitor(object Sender, StateEventArgs e)
        {
            string Estado = e.State;
            if (Estado.Equals("Up"))
            {
                Init();
            }
            else if (Estado.Equals("Down"))
            {

            }
            else
            {
                //abrir ventana config
            }

        }

        public void Init()
        {
            TimeStart.Interval = 3000;
            TimeStart.Enabled = true;
            TimeStart.Elapsed += TimeStart_Elapsed;
            TimeStart.Start();
        }
        
        private void TimeStart_Elapsed(object sender, ElapsedEventArgs e)
        {

            NewChallenge();
            TimeStart.Stop();
        }

        private void NewChallenge()
        {
            if (FrmUser == null) FrmUser = new UserForm();
            FrmUser.Show();
        }
    }
}
