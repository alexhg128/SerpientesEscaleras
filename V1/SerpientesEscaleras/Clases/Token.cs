using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpientesEscaleras.Clases
{
    class Token
    {
        string nombre;
        int posicion;

        public Token(string nombre)
        {//Inicializa a cada jugador
            posicion = 1;
            this.nombre = nombre;
        }

        public int Posicion { get => posicion; set => posicion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public void Move(int casilla)
        {//Mueve al jugador
            posicion = casilla;
        }
    }
}
