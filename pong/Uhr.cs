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
        public Double X, Y;

        public Uhr(Canvas _cvs, double X = 80, double Y = 80, double radius = 40)
        {
            this.X = X; //breite
            this.Y = Y; //höhe

            eli = new Ellipse();
            eli.Width = 2 * radius;
            eli.Height = 2 * radius;

            eli.StrokeThickness = 1.5;

            eli.Fill = Brushes.FloralWhite;

            Canvas.SetLeft(eli, X - radius);
            Canvas.SetTop(eli, Y - radius);

            secZeiger = new Zeiger(eli, 0);
            secZeiger.draw(_cvs);
            minZeiger = new Zeiger(eli, 5);
            minZeiger.draw(_cvs);
            stdZeiger = new Zeiger(eli, 10);
            stdZeiger.draw(_cvs);          
        }

        //Winkeländerung pro Sekunde
        public void updateUhr(double T_sec)
        {            
            secZeiger.angle = Math.PI * T_sec / 30;
            secZeiger.updateZeiger();

            minZeiger.angle = Math.PI * T_sec / 1800;
            minZeiger.updateZeiger();

            stdZeiger.angle = Math.PI * T_sec / 21600;
            stdZeiger.updateZeiger();
        }

        public void draw(Canvas c)
        {            
            if (!c.Children.Contains(eli))
            {
                c.Children.Add(eli);
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
