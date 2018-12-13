using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.View
{
    public class Affichage : InterfaceAffichage
    {
        public void afficherLine(string str)
        {
            Console.WriteLine(str);
        }

        public void afficher(string str)
        {
            Console.Write(str);
        }
    }
}
