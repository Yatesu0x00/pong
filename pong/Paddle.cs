using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace pong
{
    class Paddle
    {
        Rectangle rect;
        
        public Rectangle Rect
        {
            get { return rect; }
            set { value = rect; }
        }

        public double vY { get; set; }

        public Paddle(double height = 100, double width = 25, double _vY = 10)
        {
            rect = new Rectangle();
            rect.Height = height;
            rect.Width = width;
            this.vY = _vY;
            rect.Fill = Brushes.FloralWhite;
        }

        public void collision(Rectangle r)
        {
            if(Canvas.GetTop(rect) < Canvas.GetTop(r))
            {
                Canvas.SetTop(rect, Canvas.GetTop(r));
            }
            else
            {
                if(Canvas.GetTop(rect) + rect.Height <= Canvas.GetTop(r) + r.Height)
                {
                    return;
                }
                Canvas.SetTop(rect, Canvas.GetTop(r) + r.Height - rect.Height);
            }
        }

        public void position(double posY, double posX)
        {
            Canvas.SetLeft(rect, posX);
            Canvas.SetTop(rect, posY);
        }

        public void draw(Canvas c)
        {
            if (!c.Children.Contains(rect))
            {
                c.Children.Add(rect);
            }
        }

        public void undraw(Canvas c)
        {
            if (c.Children.Contains(rect))
            {
                c.Children.Remove(rect);
            }
        }

        public void Resize(double sx, double sy)
        {
            rect.Width = rect.Width * sx;
            rect.Height = rect.Height * sy;

            vY *= sy;

            Canvas.SetLeft(rect, sx * Canvas.GetLeft(rect));
            Canvas.SetTop(rect, sy * Canvas.GetTop(rect));
        }

        public void move(double dir, double dt)
        {
            Canvas.SetTop(rect, Canvas.GetTop(rect) + dir * vY * dt / 1000);
        }
    } 
}