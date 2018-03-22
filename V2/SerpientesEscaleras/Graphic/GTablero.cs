using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerpientesEscaleras.Logic;
using System.Windows.Forms;
using System.Drawing;

namespace SerpientesEscaleras.Graphic
{
    class GTablero:Tablero
    {
        static Panel panel;
        const int filas = 5;
        const int columnas = 6;
 
        public GTablero(Panel container):base()
        {
            panel = container;
        }

        public static Point calculatePosition(int casilla, Panel panel1)
        {
            panel = panel1;
            int fila = (int)((casilla - 1) / columnas + 1);
            int columna = (int)(casilla - (fila - 1) * columnas);
            int columnaReal = columna;
            if(fila % 2 == 0)
            {
                columnaReal = swap(columna);
            }

            
            int Bottom = panel.Bottom;
            int Left = panel.Left;
            

            int casillaWidth = panel.Width / columnas;
            int casillaHeight = panel.Height / filas;

            int startWidht = casillaWidth / 2;
            int startHeight = panel.Height - (casillaHeight / 2);

            return new Point(startWidht + (casillaWidth * (columnaReal - 1)), startHeight - (casillaHeight * (fila - 1)));
        }

        private static int swap(int columna)
        {
            int max = 6;
            int min = 1;
            int distance = max - columna;
            return min + distance;
        }
    }
}
