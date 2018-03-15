using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpientesEscaleras.Clases
{
    class Casilla
    {
        int numero;
        int destino;

        public int Destino { get => destino; set => destino = value; }
        public int Numero { get => numero; set => numero = value; }
        public Casilla(int a)
        {//Inicializa las casillas con la ayuda del constructor de tablero.
            numero = a;
            destino = a;
        }
    }
}
