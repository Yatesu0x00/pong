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
        public int sec, min, h;
        Canvas Cvs;

        public Uhr(Canvas _cvs)
        {
            Cvs = _cvs;

            eli = new Ellipse();
            eli.Width = 80;
            eli.Height = 80;
            eli.Stroke = Brushes.Black;
            eli.StrokeThickness = 1.5;
            eli.Fill = Brushes.FloralWhite;

            //Die hälfte der Uhr festlegen deswegen - Radius
            Canvas.SetLeft(eli, 700 - 40); 
            Canvas.SetTop(eli, 80 - 40);

            //Zeiger Wert auf 0 setzten
            sec = 0;
            min = 0;
            h = 0;

            //draw zeiger mit länge -> länge pro Zeiger -15
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
            //Umrechnung von sek -> min -> std
            sec++;
            if (sec == 3600)
            {
                min++;
                sec = 0;
            }
            if (min == 60)
            {
                h++;
                min = 0;
            }

            //Winkelberechnung für die jeweiligen Zeiger aufrufen
            secZeiger.angle = getAngle(1);
            secZeiger.draw(Cvs);
            minZeiger.angle = getAngle(2);
            minZeiger.draw(Cvs);
            stdZeiger.angle = getAngle(3);
            stdZeiger.draw(Cvs);
        }

        //Winkelberechnung
        private double getAngle(int zeiger)
        {
            if (zeiger == 1)
            {
                return (2 * Math.PI / 3600) * sec;
            }
            else if (zeiger == 2)
            {
                return (2 * Math.PI / 60) * min;
            }
            else
            {
                return (2 * Math.PI / 12) * h;
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

            //Uhr durch 2 Teilen X und Y und den längen unterschied jeweiligen Zeiger festlegen
            secZeiger.resize(Canvas.GetLeft(eli) + eli.Width / 2, Canvas.GetTop(eli) + eli.Width / 2, eli.Width / 2, 0);
            minZeiger.resize(Canvas.GetLeft(eli) + eli.Width / 2, Canvas.GetTop(eli) + eli.Width / 2, eli.Width / 2, 15);
            stdZeiger.resize(Canvas.GetLeft(eli) + eli.Width / 2, Canvas.GetTop(eli) + eli.Width / 2, eli.Width / 2, 30);
        }
    }
}
