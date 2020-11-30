using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace pong
{
    class Ball
    {
        public Ellipse Elli { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public Double Vx { get; set; }
        public Double Vy { get; set; }
        public Double Radius { get; set; }
        public int countLeft { get; set; }
        public int countRight { get; set; }
        public Double speed { get; set; }

        public Ball(Double X = 100, Double Y = 100, Double Vx = 20, Double Vy = 20, Double Radius = 10, Double Speed = 1)
        {
            this.X = X;
            this.Y = Y;
            this.Vx = Vx;
            this.Vy = Vy;
            this.Radius = Radius;
            this.speed = Speed;

            Elli = new Ellipse();
            Elli.Width = 2 * Radius;
            Elli.Height = 2 * Radius;
            Elli.Fill = Brushes.NavajoWhite;

            Canvas.SetLeft(Elli, X - Radius);
            Canvas.SetTop(Elli, Y - Radius);

            countLeft = 0;
            countRight = 0;
        }

        public void Draw(Canvas c)
        {
            if (!c.Children.Contains(Elli))
            {
                c.Children.Add(Elli);
            }
        }

        public void UnDraw(Canvas c)
        {
            if (c.Children.Contains(Elli))
            {
                c.Children.Remove(Elli);
            }
        }

        public void Resize(double sx, double sy)
        {
            X *= sx;
            Y *= sy;

            Vx *= sx;
            Vy *= sy;

            Radius *= (sx + sy) / 2;

            Elli.Width *= (sx + sy) / 2;
            Elli.Height *= (sx + sy) / 2;

            Canvas.SetLeft(Elli, sx * Canvas.GetLeft(Elli));
            Canvas.SetTop(Elli, sy * Canvas.GetTop(Elli));
        }

        public void Move(Double dt, double speed)
        {
            X = X + Vx * dt / 1000 * speed;
            Y = Y + Vy * dt / 1000 * speed;
        }

        public void Collision(Rectangle r, TextBlock left, TextBlock right)
        {
            // Obere oder untere Bande
            if (Y - Radius <= Canvas.GetTop(r))
            {
                Vy = -Vy;                                       
                Y = Y + 2 * (Canvas.GetTop(r) - (Y - Radius));  
            }
            else if (Y + Radius >= Canvas.GetTop(r) + r.Height)
            {
                Vy = -Vy;
                Y = Y - 2 * (Y + Radius - Canvas.GetTop(r) - r.Height);
            }

            // Linke oder rechte Bande
            if (X - Radius <= Canvas.GetLeft(r))
            {
                Vx = -Vx;
                X = X + 2 * (Canvas.GetLeft(r) - (X - Radius));
                
                 // Counter rechts hochzählen 
                 countRight++;
                 right.Text = countRight.ToString();              
            }
            else if (X + Radius >= Canvas.GetLeft(r) + r.Width)
            {
                Vx = -Vx;
                X = X - 2 * (X + Radius - Canvas.GetLeft(r) - r.Width);

                // Counter links hochzählen 
                countLeft++;
                left.Text = countLeft.ToString();               
            }

            Canvas.SetLeft(Elli, X - Radius);
            Canvas.SetTop(Elli, Y - Radius);
        }

        public void collisionPaddle(Rectangle r)
        {
            
            if ((X >= Canvas.GetLeft(r)) && (X <= Canvas.GetLeft(r) + r.Width)) //Rechte und Linke Kante ausschließen
            {
                //obere Kante
                if (((Y + Radius) >= Canvas.GetTop(r)) && (Y - Radius <= Canvas.GetTop(r)))  
                {
                    Vy = -Vy;
                    Y = Y - 2 * ((Y + Radius) - Canvas.GetTop(r));
                }
                //untere Kante
                else if (((Y - Radius) <= (Canvas.GetTop(r) + r.Height)) && ((Y + Radius) >= (Canvas.GetTop(r) + r.Height))) 
                {
                    Vy = -Vy;
                    Y = Y + 2 * ((Canvas.GetTop(r) + r.Height) - (Y - Radius));
                }
            }
            //Rechte Kante
            if ((X - Radius <= Canvas.GetLeft(r) + r.Width) && (X - Radius > Canvas.GetLeft(r)) && (Y + Radius > Canvas.GetTop(r)) && (Y - Radius < Canvas.GetTop(r) + r.Height))
            {
                Vx = -Vx;
                X = X + 2 * (Canvas.GetLeft(r) + r.Width - (X - Radius));
            }
            //linke Kante
            else if ((X + Radius >= Canvas.GetLeft(r)) && (X + Radius < Canvas.GetLeft(r) + r.Width) && (Y + Radius > Canvas.GetTop(r)) && (Y - Radius < Canvas.GetTop(r) + r.Height))
            {
                Vx = -Vx;
                X = X - 2 * (X + Radius - Canvas.GetLeft(r));
            }
        }
    }
}

