using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerpientesEscaleras.Clases;
namespace SerpientesEscaleras
{
    class Program
    {
        //Alejandro Hahn Gallegos A01561774
        //Jonatan Isael Meza Sotelo A01560882
        //Daniel Armando Núñez Delgadillo A01561730
        //Alejandro Anguiano Gutiérrez A01566462
        static int nJugadores;

        static void Main(string[] args)
        {
            Tablero tablero = new Tablero();

            while (true)
            {
                Turno turno = new Turno(tablero);
                Console.WriteLine("Bienvenido a Serpientes y escaleras V1.0");
                IntroducirJugadores();
                List<string> jugadores = new List<string>();
                for (int i = 0; i < nJugadores; i++)
                {//Introduces el nombre de cada jugador
                    Console.WriteLine("\nIntroduce el nombre del jugador {0}", i + 1);
                    string name = IntroducirNombre(jugadores);
                    Token jugador = new Token(name);
                    turno.addPlayer(jugador);
                    jugadores.Add(name);
                }

                while (turno.Ganador == null)
                {//Ejecuta los turnos hasta que alla un ganador
                    turno.siguienteTurno();
                    Console.ReadKey();
                }

                Console.WriteLine("\n{0} ha ganado la partida", turno.Ganador.Nombre);

                Console.WriteLine("Deseas juagar nuevamente?", turno.Ganador.Nombre);
                try
                {
                    char car = Console.ReadLine().ToCharArray()[0];
                    if (car != 'y')//Pregunta si deseas continuar jugando
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }

                Console.ReadKey();
            }

        }
        private static string IntroducirNombre(List<string> lista)
        {//Pide los nombres de los jugadores y si se repite o es nulo lo rechaza
            while (true)
            {
                string name;
                name = Console.ReadLine();
                if (name != string.Empty && !lista.Contains(name))
                {
                    return name;
                }
            }
        }
        private static void IntroducirJugadores()
        {
            while (true)
            {//Revisa que lo introducido a los jugadores sea un numero, de lo contrario repite
                
                try
                {
                    Console.WriteLine("\n\nIntroduce el numero de jugadores\n");
                    nJugadores = int.Parse(Console.ReadLine());
                    if (nJugadores > 0)
                    {//Evita la introduccion de 0 o negativos
                        return;
                    }
                    Console.WriteLine("\nPorfavor introduce solo numeros positivos excluyendo el 0");
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPorfavor introduce solo numeros");
                }
            }
        }

    }
}
