using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace SerpientesEscaleras.Graphic
{
    class GDice
    {
        static Form1 instance;
        Random random;
        static System.Timers.Timer aTimer = new System.Timers.Timer();

        public GDice(Form1 form)
        {
            instance = form;
            random = new Random();
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(Animation);
            aTimer.Interval = 40;
        }

        public int RollDice()
        {
            int dice = random.Next(1, 7);
            ExecuteAnimation(dice);
            return dice;
        }

        
        static int objective;
        static int round = 0;
        static int count = 0;

        private void ExecuteAnimation(int number)
        {
            objective = number;
            
            aTimer.Enabled = true;

            round = 0;
        }

        private void Animation(object source, ElapsedEventArgs e)
        {
            if(round == 3 && count == objective)
            {
                round = 0;
                aTimer.Stop();
                return;
            }
            switch(count)
            {
                case 0:
                    count = 1;
                    instance.updateDice("1");
                    break;
                case 1:
                    count = 2;
                    instance.updateDice("2");
                    break;
                case 2:
                    count = 3;
                    instance.updateDice("3");
                    break;
                case 3:
                    count = 4;
                    instance.updateDice("4");
                    break;
                case 4:
                    count = 5;
                    instance.updateDice("5");
                    break;
                case 5:
                    count = 6;
                    instance.updateDice("6");
                    break;
                case 6:
                    count = 1;
                    round++;
                    instance.updateDice("1");
                    break;

            }
            
        }

        private static void updateCounters(int a, int b)
        {

        }

        private static int getRound()
        {
            return round;
        }

    }
}
