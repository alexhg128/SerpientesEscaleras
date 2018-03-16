using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpientesEscaleras.Logic
{
    class Dado
    {

        public static int getRandom()
        {
            Random rnd = new Random();
            return rnd.Next(1, 7);//Tira el dado
        }

    }
}
