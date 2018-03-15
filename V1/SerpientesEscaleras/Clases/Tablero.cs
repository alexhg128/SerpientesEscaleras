using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpientesEscaleras.Clases
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
            Casillas[3 - 1].Destino = 9;
            Casillas[7 - 1].Destino = 17;
            Casillas[11 - 1].Destino = 2;
            Casillas[13 - 1].Destino = 1;
            Casillas[15 - 1].Destino = 22;
            Casillas[16 - 1].Destino = 8;
            Casillas[23 - 1].Destino = 28;
            Casillas[21 - 1].Destino = 18;
            Casillas[19 - 1].Destino = 29;
            Casillas[25 - 1].Destino = 6;
            Casillas[27 - 1].Destino = 8;
        }
        public Casilla GetCasilla(int a)
        {//Regresa la casilla en la que te encuentras
            return Casillas[a - 1];
        }
    }
}
