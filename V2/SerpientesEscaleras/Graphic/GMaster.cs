using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerpientesEscaleras.Logic;
using System.Windows.Forms;

namespace SerpientesEscaleras.Graphic
{
    class GMaster:Turno
    {
        Panel panel;
        Form1 form;
        GToken current;
        GDice dado;

        public GMaster(GTablero tab, Panel panel, Form1 form):base(tab)
        {
            this.panel = panel;
            this.form = form;
            dado = new GDice(form);
        }

        public void Reset()
        {
            foreach(Token t in Fila)
            {
                t.Posicion = 1;
                GToken tt = (GToken)t;
                tt.Label.Location = GTablero.calculatePosition(1, panel);
            }
            Ganador = null;
        }

        public void Resize()
        {
            foreach (Token t in Fila)
            {
                GToken tt = (GToken)t;
                tt.Label.Location = GTablero.calculatePosition(tt.Posicion, panel);
            }
        }

        internal GToken Current { get => current; set => current = value; }

        public override void siguienteTurno()
        {
            current = (GToken) this.Fila.Dequeue();//Toma el jugador en turno
            int avance = dado.RollDice();//Tira el dado
            int destino;
            int pa = current.Posicion + avance;//Determina la casilla a la que caes
            if (current.Posicion + avance > 30)
            {//Si excedes el tablero empiezas a retroceder
             //for (int i = current.Posicion; i < 30; i++)
             //{
             //    //Animator.Animate(GTablero.calculatePosition(i, panel), i + 1, form, panel);

                //}
                
                destino = 30 - (pa - 30);
                destino = this.Tablero.GetCasilla(destino).Destino;//Analiza si caes en una casilla especial despues de retroceder
                //for (int i = 30; i != destino; i++)
                //{
                //    Animator.Animate(GTablero.calculatePosition(i, panel), i - 1, form, panel);
                //}
                form.updateTokenCoord(GTablero.calculatePosition(destino, panel));
                
            }
            else if (current.Posicion + avance == 30)
            {//Si llegas al final proclama ganador al jugador en turno
                destino = 30;
                this.Ganador = current;
                form.updateTokenCoord(GTablero.calculatePosition(destino, panel));
            }
            else
            {//Determina si caiste en una casilla especial para moverte
                //for (int i = current.Posicion; i < pa; i++)
                //{
                //    Animator.Animate(GTablero.calculatePosition(i, panel), i + 1, form, panel);
                //}
                destino = this.Tablero.GetCasilla(current.Posicion + avance).Destino;
                //Animator.Animate(GTablero.calculatePosition(current.Posicion, panel), destino, form, panel);
                form.updateTokenCoord(GTablero.calculatePosition(destino, panel));
            }

            current.Posicion = destino;//Define tu posicion final
            this.Fila.Enqueue(current);//Pone al jugador en turno al final de la fila

            

            

        }

        public GToken DeletePlayer(string Nombre)
        {
            while(true)
            {
                GToken t = (GToken)Fila.Dequeue();
                if(t.ToString() == Nombre)
                {
                    return t;
                }
                else
                {
                    Fila.Enqueue(t);
                }
            }
        }

    }
}
