using Salle.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Salle.Controller
{
    public class Pause
    {
        public static List<Thread> ThreadList = new List<Thread>();

        public void AddThread(Thread th)
        {
            ThreadList.Add(th);
        }

        public static bool paused = false;

        public void PauseThreads()
        {
            try
            {
                foreach (Thread th in ThreadList)
                {
                    if (th.IsAlive)
                    {
                        if (!paused)
                        {
                            new Affichage().afficherLine("\n----------Salle paused----------");
                        }
                        paused = true;
                        th.Suspend();
                    }
                }
            }
            catch (Exception e)
            {
                new Affichage().afficherLine(e.ToString());
            }
        }

        public void Resume()
        {
            try
            {
                if (paused)
                {
                    foreach (Thread th in ThreadList)
                    {
                        if (th.IsAlive)
                        {
                            th.Resume();
                            if (paused)
                            {
                                new Affichage().afficherLine("\n----------Salle Resumed----------\n");
                            }
                        }
                        paused = false;
                    }
                }
            }
            catch (Exception e)
            {
                new Affichage().afficherLine(e.ToString());
            }
        }

    }
}
