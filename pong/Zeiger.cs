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
        
        public Zeiger(double X1 = 660, double Y1 = 100, double _length = 60, double _angle = 0) 
        {
            li = new Line();
            length = _length;
            angle = _angle;
            li.X1 = X1;
            li.Y1 = Y1;                     
        }

        public void draw(Canvas c)
        {
            double gk, ak;
            gk = length * Math.Sin(angle);
            ak = length * Math.Cos(angle);

            undraw(c);
            
            li.X2 = li.X1 + gk; //GK
            li.Y2 = li.Y1 - ak; //AK
            
            li.Stroke = Brushes.Black;
            li.StrokeThickness = 2;

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
