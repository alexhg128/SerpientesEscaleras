using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpientesEscaleras.Logic
{
    class Tablero
    {
        Casilla[] Casillas = new Casilla[30];
        public Tablero()//Inicializa el tablero con las 30 casillas sin definir serpientes o escaleras
        {
            for(int i = 0;i < Casillas.Length; ++i)
            {
                Casillas[i] = new Casilla(i+1);
            }
            //Asigna las serpientes y escaleras
            Casillas[3 - 1].Destino = 22;
            Casillas[5 - 1].Destino = 8;
            Casillas[11 - 1].Destino = 26;
            Casillas[17 - 1].Destino = 4;
            Casillas[19 - 1].Destino = 7;
            Casillas[20 - 1].Destino = 29;
            Casillas[21 - 1].Destino = 9;
            Casillas[27 - 1].Destino = 1;

        }
        public Casilla GetCasilla(int a)
        {//Regresa la casilla en la que te encuentras
            return Casillas[a - 1];
        }
    }
}
