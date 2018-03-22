using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerpientesEscaleras.Logic;
using System.Windows.Forms;

namespace SerpientesEscaleras.Graphic
{
    class GToken:Token
    {
        Label label;
        

        public GToken(Label label, string nombre):base(nombre)
        {
            this.label = label;
        }

        public Label Label { get => label; set => label = value; }
        

    }
}
