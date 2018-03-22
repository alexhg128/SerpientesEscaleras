using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Timers;

namespace SerpientesEscaleras.Graphic
{
    class Animator
    {

        static System.Timers.Timer aTimer = new System.Timers.Timer();

        public static void Animate(Point current, int casillaDestino, Form1 form, Panel panel)
        {
            Point destination = GTablero.calculatePosition(casillaDestino, panel);
            instance = form;
            distanceX = destination.X - current.X;
            distanceY = destination.Y - current.Y;
            stepX = distanceX / 100;
            stepY = distanceY / 100;
            currentX = current.X;
            currentY = current.Y;
            destinationX = destination.X;
            destinationY = destination.Y;
            aTimer.Elapsed += new ElapsedEventHandler(Animation);
            aTimer.Interval = 40;
            aTimer.Enabled = true;
        }

        public static void Animate(Point current, Point destination, Form1 form)
        {
            instance = form;
            distanceX = destination.X - current.X;
            distanceY = destination.Y - current.Y;
            stepX = distanceX / 100;
            stepY = distanceY / 100;
            currentX = current.X;
            currentY = current.Y;
            destinationX = destination.X;
            destinationY = destination.Y;
            aTimer.Elapsed += new ElapsedEventHandler(Animation);
            aTimer.Interval = 40;
            aTimer.Enabled = true;
        }

        static Form1 instance;
        static int counter;
        static int step = 100;
        static int destinationX;
        static int destinationY;
        static int distanceX;
        static int distanceY;
        static int stepX;
        static int stepY;
        static int currentX;
        static int currentY;


        private static void Animation(object source, ElapsedEventArgs e)
        {
            if(counter <= step)
            {
                currentX += stepX;
                currentY += stepY;
                instance.updateTokenCoord(new Point(currentX, currentY));
                counter++;
            } else
            {
                currentX = destinationX;
                currentY = destinationY;
                instance.updateTokenCoord(new Point(currentX, currentY));
                counter = 0;
                aTimer.Stop();
            }

            

        }

    }
}
