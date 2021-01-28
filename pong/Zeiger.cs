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
    class Zeiger
    {
        Line li;
        public double length { get; set; }
        public double angle { get; set; }

        public Zeiger(Ellipse eli, int _length)
        {
            angle = 0; //standard position von Zeiger

            li = new Line();

            li.Stroke = Brushes.Black;
            li.StrokeThickness = 2;

            li.X1 = Canvas.GetLeft(eli) + eli.Width / 2;
            li.Y1 = Canvas.GetTop(eli) + eli.Height / 2;

            this.length = eli.Width / 2 - _length;
            li.X2 = li.X1;
            li.Y2 = li.Y1 - this.length;

            Panel.SetZIndex(li, 1); //Zeigerfarbe über die Uhrfarbe
        }

        //Position der Zeigerspitze
        public void updateZeiger()
        {
            li.X2 = li.X1 + length * Math.Sin(angle);
            li.Y2 = li.Y1 - length * Math.Cos(angle);
        }

        public void draw(Canvas c)
        {
            if (!c.Children.Contains(li))
            {
                c.Children.Add(li);
            }
        }

        public void undraw(Canvas c)
        {
            if (c.Children.Contains(li))
            {
                c.Children.Remove(li);
            }
        }

        public void resize(double sx, double sy, double _length, double zeigerLengthNew)
        {
            length = _length - zeigerLengthNew;
            li.X1 = sx;
            li.Y1 = sy;

            li.X2 = li.X1 + length * Math.Sin(angle);
            li.Y2 = li.Y1 - length * Math.Cos(angle);

            li.Width *= ((sx + sy) / 2);
            li.Height *= ((sx + sy) / 2);
            Canvas.SetTop(li, sy * Canvas.GetTop(li));
            Canvas.SetLeft(li, sx * Canvas.GetLeft(li));
        }
    }
}
