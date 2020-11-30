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
using System.Windows.Shapes;

namespace pong
{
    public partial class StartDlg : Window
    {
        public Double Radius { get; set; }
        public string spieler1 { get; set; }
        public string spieler2 { get; set; }
        public Double paddleHoehe { get; set; }
        public Double paddleBreite { get; set; }
        public Double paddleVy { get; set; }
        public Double p1 { get; set; }
        public Double p2 { get; set; }
        public bool autoMode { get; set; } //KI

        public StartDlg()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Radius = Convert.ToDouble(radius.Text);
                paddleBreite = Convert.ToDouble(tbPaddleBreite.Text);
                paddleHoehe = Convert.ToDouble(tbPaddleHoehe.Text);
                spieler1 = Convert.ToString(tbNameP1.Text + ": W=Up | S=Down");
                spieler2 = Convert.ToString(tbNameP2.Text + ": Up Arrow=Up | Down Arrow=Down");
                paddleVy = Convert.ToDouble(tbPaddleVy.Text);

                //Parameter abfragen
                if (Radius < 1 || Radius > 15)
                {
                    throw new Exception("Der Radius muss zwischen 1 und 15 liegen!");
                }
                else if(paddleBreite < 15 || paddleBreite > 40)
                {
                    throw new Exception("Die Paddle Breite muss zwischen 15 und 40 liegen!");
                }
                else if(paddleHoehe < 50 || paddleHoehe > 150)
                {
                    throw new Exception("Die Paddle Höhe muss zwischen 50 und 150 liegen!");
                }
                else if(paddleVy < 15 || paddleVy > 25)
                {
                    throw new Exception("Die Paddle Geschwindigkeit muss zwischen 15 und 25 liegen!");
                }
                else
                {
                    DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message, "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //KI an oder aus
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            autoMode = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            autoMode = false;
        }
    }
}
