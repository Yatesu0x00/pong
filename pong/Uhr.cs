using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace pong
{
    class Uhr
    {
        Ellipse eli;
        Zeiger secZeiger, minZeiger, stdZeiger;
        DispatcherTimer timer;
        Canvas Cvs;
        public int sek, min, std;

        public Uhr(Canvas _cvs)
        {
            Cvs = _cvs;

            eli = new Ellipse();
            eli.Width = 2 * 40;
            eli.Height = 2 * 40;
            eli.Stroke = Brushes.Black;
            eli.StrokeThickness = 1.5;
            eli.Fill = Brushes.FloralWhite;

            Canvas.SetLeft(eli, 700 - 40);
            Canvas.SetTop(eli, 80 - 40);

            sek = 0;
            min = 0;
            std = 0;
                     
            secZeiger = new Zeiger(700, 80, 40);
            secZeiger.draw(_cvs);
            minZeiger = new Zeiger(700, 80, 25);
            minZeiger.draw(_cvs);
            stdZeiger = new Zeiger(700, 80, 10);
            stdZeiger.draw(_cvs);

            Cvs.Children.Add(eli); //draw

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        public void start_Timer()
        {
            timer.Start(); //Damit er von mainWindow Timer_Click aufrufbar ist
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            sek++;
            if (sek == 3600)
            {
                min++;
                sek = 0;
            }
            if (min == 60)
            {
                std++;
                min = 0;
            }

            secZeiger.angle = getAngle(1);
            secZeiger.draw(Cvs);
            minZeiger.angle = getAngle(2);
            minZeiger.draw(Cvs);
            stdZeiger.angle = getAngle(0);
            stdZeiger.draw(Cvs);
        }
        private double getAngle(int zustand)
        {
            if (zustand == 1)
            {
                return (2 * Math.PI / 3600) * sek;
            }
            else if (zustand == 2)
            {
                return (2 * Math.PI / 60) * min;
            }
            else
            {
                return (2 * Math.PI / 12) * std;
            }
        }

        public void undraw(Canvas c)
        {
            if (c.Children.Contains(eli))
            {
                c.Children.Remove(eli);
            }
        }

        public void resize(double sx, double sy)
        {
            eli.Width *= (sx + sy) / 2;
            eli.Height *= (sx + sy) / 2;

            Canvas.SetLeft(eli, sx * Canvas.GetLeft(eli));
            Canvas.SetTop(eli, sy * Canvas.GetTop(eli));

             secZeiger.resize(Canvas.GetLeft(eli) + eli.Width / 2, Canvas.GetTop(eli) + eli.Width / 2, eli.Width / 2, 0);
             minZeiger.resize(Canvas.GetLeft(eli) + eli.Width / 2, Canvas.GetTop(eli) + eli.Width / 2, eli.Width / 2, 15);
             stdZeiger.resize(Canvas.GetLeft(eli) + eli.Width / 2, Canvas.GetTop(eli) + eli.Width / 2, eli.Width / 2, 30);
        }
    }
}
