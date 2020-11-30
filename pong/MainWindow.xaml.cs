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
    public partial class MainWindow : Window
    {
        StartDlg dlg;
        Ball ball;
        DispatcherTimer timer;
        Double ticks_old;
        Paddle paddle1, paddle2;
        Uhr uhr;

        public double slideBarBallSpeed { get; set; }
        public double fps { get; set; }
        public int sek { get; set; }
        public int min { get; set; }
        public int std { get; set; }
        private bool p2CanMove;
        private double extraSpeed; //KI never lose! cuz of this variable/ extra speed for catching the ball in every shape
        public MainWindow()
        {
            dlg = new StartDlg();

            if ((bool)dlg.ShowDialog())
            {
                InitializeComponent();
            }
            else
            {
                Close();
            }

            lbP1.Content = dlg.spieler1;
            lbP2.Content = dlg.spieler2;
        }

        private void wnd_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 15);

            ball = new Ball(250, 150, 200, 200, dlg.Radius);
            ball.Draw(Cvs);
          
            paddle1 = new Paddle(dlg.paddleHoehe, dlg.paddleBreite);
            paddle1.position(174, 119);       
            paddle1.draw(Cvs);
            
            paddle2 = new Paddle(dlg.paddleHoehe, dlg.paddleBreite);
            paddle2.position(174, 559);
            paddle2.draw(Cvs);

            uhr = new Uhr(Cvs);

            extraSpeed = 1.2;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Double ticks = Environment.TickCount;

            ball.Move(ticks - ticks_old, ball.speed);
            ball.Collision(RectFeld, tbCountLeft, tbCountRight);

            getFPS(ticks);

            slider();
            
            //Player 1 - paddle on the left
            if (Keyboard.IsKeyDown(Key.S))
            {
                paddle1.move(ticks - ticks_old, dlg.paddleVy);
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                paddle1.move(ticks - ticks_old, -dlg.paddleVy);
            }
            
            //Player 2 - paddle on the right
            if(dlg.autoMode == false)
            {
                p2CanMove = true;
            }
            else
            {
                p2CanMove = false;
            }
            if(p2CanMove == true)
            {
                if (Keyboard.IsKeyDown(Key.Down))
                {
                    paddle2.move(ticks - ticks_old, dlg.paddleVy);
                }
                else if (Keyboard.IsKeyDown(Key.Up))
                {
                    paddle2.move(ticks - ticks_old, -dlg.paddleVy);
                }
            }
                    
            ball.collisionPaddle(paddle1.Rect);
            ball.collisionPaddle(paddle2.Rect);

            paddle1.collision(RectFeld);
            paddle2.collision(RectFeld);
            
            //Automatischer Paddle
            if(dlg.autoMode == true && ball.Vx > 0)
            {
                double t = Canvas.GetLeft(paddle2.Rect) - ball.X / ball.Vx;
                double yt = ball.Y + ball.Vy / t;

                if (yt < Canvas.GetTop(paddle2.Rect) + paddle2.Rect.Height / 2 && Canvas.GetTop(paddle2.Rect) > Canvas.GetTop(RectFeld) + 5)
                {
                    paddle2.move(ticks - ticks_old, -dlg.paddleVy * ball.speed * extraSpeed);
                }
                else if (yt > Canvas.GetTop(paddle2.Rect) + paddle2.Rect.Height / 2 && Canvas.GetTop(paddle2.Rect) + paddle2.Rect.Height < Canvas.GetTop(RectFeld) + RectFeld.Height - 5) 
                {
                    paddle2.move(ticks - ticks_old, dlg.paddleVy * ball.speed * extraSpeed);
                }
            }

            ticks_old = ticks;
        }

        private void getFPS(double _ticks)
        {
            fps = 1 / (_ticks - ticks_old) * 1000;
            fps = Math.Round(fps);
            lbFPS.Content = fps;
        }

        private void slider()
        {
            sliderBallVelocity.Value = Math.Round(sliderBallVelocity.Value, 1);
            lbBallVelocity.Content = sliderBallVelocity.Value;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            ticks_old = Environment.TickCount;

            timer.Start();

            uhr.start_Timer();
        }

        private void ende_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void BtnApplyBallVelocity_Click(object sender, RoutedEventArgs e)
        {
            ball.speed = sliderBallVelocity.Value;
        }

        private void Cvs_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                Double sx = e.NewSize.Width / e.PreviousSize.Width;
                Double sy = e.NewSize.Height / e.PreviousSize.Height;

                //Klassenspezifischer resize
                ball.Resize(sx, sy);
                paddle1.Resize(sx, sy);
                paddle2.Resize(sx, sy);
                uhr.resize(sx, sy);

                //Spieler1
                lbP1.FontSize *= ((sx + sy) / 2);
                lbP1.Height *= sy;
                lbP1.Width *= sx;
                Canvas.SetLeft(lbP1, sx * Canvas.GetLeft(lbP1));
                Canvas.SetTop(lbP1, sy * Canvas.GetTop(lbP1));

                //Spieler2
                lbP2.FontSize *= ((sx + sy) / 2);
                lbP2.Height *= sy;
                lbP2.Width *= sx;
                Canvas.SetLeft(lbP2, sx * Canvas.GetLeft(lbP2));
                Canvas.SetTop(lbP2, sy * Canvas.GetTop(lbP2));

                //":" Text
                lbCountBreak.FontSize *= ((sx + sy) / 2);
                lbCountBreak.Height *= sy;
                lbCountBreak.Width *= sx;
                Canvas.SetLeft(lbCountBreak, sx * Canvas.GetLeft(lbCountBreak));
                Canvas.SetTop(lbCountBreak, sy * Canvas.GetTop(lbCountBreak));

                //Spielfeld
                RectFeld.Width *= sx;
                RectFeld.Height *= sy;
                Canvas.SetLeft(RectFeld, sx * Canvas.GetLeft(RectFeld));
                Canvas.SetTop(RectFeld, sy * Canvas.GetTop(RectFeld));

                //Linker zähler
                tbCountLeft.FontSize *= ((sx + sy) / 2);
                tbCountLeft.Width *= sx;
                tbCountLeft.Height *= sy;
                Canvas.SetTop(tbCountLeft, sy * Canvas.GetTop(tbCountLeft));
                Canvas.SetLeft(tbCountLeft, sx * Canvas.GetLeft(tbCountLeft));

                //Rechter zähler
                tbCountRight.FontSize *= ((sx + sy) / 2);
                tbCountRight.Width *= sx;
                tbCountRight.Height *= sy;
                Canvas.SetTop(tbCountRight, sy * Canvas.GetTop(tbCountRight));
                Canvas.SetLeft(tbCountRight, sx * Canvas.GetLeft(tbCountRight));              

                //FPS Ausgabe
                lbFPS.FontSize *= ((sx + sy) / 2);
                lbFPS.Width *= sx;
                lbFPS.Height *= sy;           
                Canvas.SetTop(lbFPS, sy * Canvas.GetTop(lbFPS));
                Canvas.SetLeft(lbFPS, sx * Canvas.GetLeft(lbFPS));

                //"FPS" Text
                lbFPSSee.FontSize *= ((sx + sy) / 2);
                lbFPSSee.Width *= sx;
                lbFPSSee.Height *= sy;
                Canvas.SetTop(lbFPSSee, sy * Canvas.GetTop(lbFPSSee));
                Canvas.SetLeft(lbFPSSee, sx * Canvas.GetLeft(lbFPSSee));

                //Ausgabe von Sliderbar minimalwert
                lbZero.Width *= sx;
                lbZero.Height *= sy;
                lbZero.FontSize *= ((sx + sy) / 2);
                Canvas.SetTop(lbZero, sy * Canvas.GetTop(lbZero));
                Canvas.SetLeft(lbZero, sx * Canvas.GetLeft(lbZero));

                //Ausgabe von Sliderbar maximalwert
                lbBallVelocity.Width *= sx;
                lbBallVelocity.Height *= sy;
                lbBallVelocity.FontSize *= ((sx + sy) / 2);
                Canvas.SetTop(lbBallVelocity, sy * Canvas.GetTop(lbBallVelocity));
                Canvas.SetLeft(lbBallVelocity, sx * Canvas.GetLeft(lbBallVelocity));

                //Bestätigungsknopf
                btnApplyBallVelocity.Width *= sx;
                btnApplyBallVelocity.Height *= sy;
                btnApplyBallVelocity.FontSize *= ((sx + sy) / 2);
                Canvas.SetTop(btnApplyBallVelocity, sy * Canvas.GetTop(btnApplyBallVelocity));
                Canvas.SetLeft(btnApplyBallVelocity, sx * Canvas.GetLeft(btnApplyBallVelocity));

                //Ballgeschwindigkeit Sliderbar
                sliderBallVelocity.Width *= sy;
                sliderBallVelocity.Height *= sx;
                Canvas.SetTop(sliderBallVelocity, sy * Canvas.GetTop(sliderBallVelocity));
                Canvas.SetLeft(sliderBallVelocity, sx * Canvas.GetLeft(sliderBallVelocity));

                //"Ballspeed" Text
                lbBallSpeed.FontSize *= ((sx + sy) / 2);
                lbBallSpeed.Width *= sx;
                lbBallSpeed.Height *= sy;
                Canvas.SetTop(lbBallSpeed, sy * Canvas.GetTop(lbBallSpeed));
                Canvas.SetLeft(lbBallSpeed, sx * Canvas.GetLeft(lbBallSpeed));
            }
            catch { }
        }
    }
}
