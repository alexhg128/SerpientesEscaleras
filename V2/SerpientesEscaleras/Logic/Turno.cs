using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerpientesEscaleras.Logic
{
    class Turno
    {

        Queue<Token> fila;
        Token ganador;
        Tablero tablero;

        public Turno(Tablero tab)
        {//Inicializa el turno y el tablero
            fila = new Queue<Token>();
            ganador = null;
            tablero = tab;
        }

        internal Token Ganador { get => ganador; set => ganador = value; }

        public void addPlayer(Token player) 
        {//Agrega un jugador a la fila de jugadores
            fila.Enqueue(player);
        }

        public void siguienteTurno()
        {
            Token current = fila.Dequeue();//Toma el jugador en turno
            int avance = Dado.getRandom();//Tira el dado
            int destino;
            int pa = current.Posicion + avance;//Determina la casilla a la que caes
            if (current.Posicion + avance > 30)
            {//Si excedes el tablero empiezas a retroceder
                destino = 30 - (pa - 30);
                destino = tablero.GetCasilla(destino).Destino;//Analiza si caes en una casilla especial despues de retroceder
            }
            else if(current.Posicion + avance == 30)
            {//Si llegas al final proclama ganador al jugador en turno
                destino = 30;
                ganador = current;
            }
            else
            {//Determina si caiste en una casilla especial para moverte
                destino = tablero.GetCasilla(current.Posicion + avance).Destino;
            }

            current.Posicion = destino;//Define tu posicion final
            fila.Enqueue(current);//Pone al jugador en turno al final de la fila

            if (pa < destino)//Define el texto segun los resultados de los movimientos
            {
                Console.WriteLine("\n{0} obtuvo {1} y avanzo a la casilla {2} pero avanzaste a {3}", current.Nombre, avance, pa, destino);
            }
            else if (pa > destino)
            {
                Console.WriteLine("\n{0} obtuvo {1} y avanzo a la casilla {2} pero retrocediste a {3}", current.Nombre, avance, pa, destino);
            }
            else
            {
                Console.WriteLine("\n{0} obtuvo {1} y avanzo a la casilla {2}", current.Nombre, avance, pa);
            }

            
             
        }

    }
}
