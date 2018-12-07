using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model;

namespace Salle
{
    class Program
    {
        static void Main(string[] args)
        {
            HallInterface salle = Hall.hallInstance();

            //fork

            while (true)
            {

                Random rnd = new Random();

                //Création random de clients

                System.Threading.Thread.Sleep(700);

            }

            while (true)
            {
                //maitre d hotel a intervalle réguilier
            }
            
        }
    }
}
