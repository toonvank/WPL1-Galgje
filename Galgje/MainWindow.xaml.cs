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
using System.Threading;

namespace Galgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string woord, geradenWoord, juist, fout, letter, lijnen;
        int levens = 10, lengteLijntjes = 0, counter = 1, counterr=10;
        bool verberg = false, gelijk = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVerberg_Click(object sender, RoutedEventArgs e)
        {
            verberg = true;
            //raadknop verbergen
            btnRaad.IsEnabled = true;
            //eerste knoppen verbergen
            btnVerberg.Visibility = Visibility.Hidden;
            lblWoord.Visibility = Visibility.Hidden;
            //labels laten tonen
            lblLevens.Visibility = Visibility.Visible;
            lblJuist.Visibility = Visibility.Visible;
            lblFout.Visibility = Visibility.Visible;
            txtResultaat.Text = string.Empty;
            txtLetter.Visibility = Visibility.Visible;

            //lijntjes genereren
            char[] lijntjes = woord.ToCharArray();
            int lengteLijntjes = lijntjes.Length;
            for (int i = 0; i < lengteLijntjes; i++)
            {
                txtResultaat.Text += "_";
            }
        }

        private void Compare()
        {
            gelijk = false;
            char[] woordArray = woord.ToCharArray();
            char[] raadArray = geradenWoord.ToCharArray();
            for (int i = 0; i <= woordArray.Length -1; i++)
            {
                if (woordArray[i] == Convert.ToChar(letter))
                {
                    gelijk = true;
                    juist += woordArray[i];
                    lijnen = txtResultaat.Text;
                    char[] vervangen = lijnen.ToCharArray();
                    vervangen[i] = Convert.ToChar(letter);
                    txtResultaat.Text = String.Empty;
                    for (int j = 0; j < vervangen.Length; j++)
                    {
                        txtResultaat.Text += Convert.ToString(vervangen[j]);
                    }
                }
            }
            if (gelijk == false)
            {
                fout += letter;
                switch (counter)
                {
                    case 1:
                        one.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        two.Visibility = Visibility.Visible;
                        break;
                    case 3:
                        three.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        four.Visibility = Visibility.Visible;
                        break;
                    case 5:
                        five.Visibility = Visibility.Visible;
                        break;
                    case 6:
                        six.Visibility = Visibility.Visible;
                        break;
                    case 7:
                        seven.Visibility = Visibility.Visible;
                        break;
                    case 8:
                        eight.Visibility = Visibility.Visible;
                        break;
                    case 9:
                        nine.Visibility = Visibility.Visible;
                        break;
                    case 10:
                        nine.Visibility = Visibility.Visible;
                        break;
                }
                counter++;
                counterr--;
                if (counterr ==0)
                {
                    MessageBox.Show("U heeft verloren");
                    btnRaad.IsEnabled = false;
                    keys.IsEnabled = false;
                }
            }
            if (txtResultaat.Text == woord)
            {
                MessageBox.Show("U heeft gewonnen!");
                btnRaad.IsEnabled = false;
                keys.IsEnabled = false;
            }
        }
        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            btnRaad.IsEnabled = true;
            verberg = false;
            woord = string.Empty;
            geradenWoord = string.Empty;
            lblNietGeraden.Visibility = Visibility.Hidden;
            lblGeraden.Visibility = Visibility.Hidden;
            lblLevens.Visibility = Visibility.Hidden;
            lblJuist.Visibility = Visibility.Hidden;
            lblFout.Visibility = Visibility.Hidden;
            txtResultaat.Text = string.Empty;
            txtLetter.Text = string.Empty;
            lblWoord.Visibility = Visibility.Visible;
            btnVerberg.Visibility = Visibility.Visible;
            txtResultaat.Background = Brushes.White;
            txtLetter.Background = Brushes.White;
            keys.IsEnabled = true;
            lblJuist.Content = "Juiste:";
            lblFout.Content = "Foute:";
            juist = String.Empty;
            fout = String.Empty;
            txtLetter.Visibility = Visibility.Hidden;
            counterr = 10;
            counter = 1;

            //stickman laten verdwijnen
            one.Visibility = Visibility.Hidden;
            two.Visibility = Visibility.Hidden;
            three.Visibility = Visibility.Hidden;
            four.Visibility = Visibility.Hidden;
            five.Visibility = Visibility.Hidden;
            six.Visibility = Visibility.Hidden;
            seven.Visibility = Visibility.Hidden;
            eight.Visibility = Visibility.Hidden;
            nine.Visibility = Visibility.Hidden;
            ten.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "a";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "a";
            }
            letter = "a";
        }

        private void b(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "b";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "b";
            }
            letter = "b";
        }

        private void c(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "c";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "c";
            }
            letter = "c";
        }

        private void d(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "d";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "d";
            }
            letter = "d";
        }

        private void e(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "e";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "e";
            }
            letter = "e";
        }

        private void f(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "f";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "f";
            }
            letter = "f";
        }

        private void g(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "g";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "g";
            }
            letter = "g";
        }

        private void h(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "h";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "h";
            }
            letter = "h";
        }

        private void i(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "i";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "i";
            }
            letter = "i";
        }

        private void j(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "j";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "j";
            }
            letter = "j";
        }

        private void k(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "k";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "k";
            }
            letter = "k";
        }

        private void l(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "l";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "l";
            }
            letter = "l";
        }

        private void m(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "m";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "m";
            }
            letter = "m";
        }

        private void n(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "n";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "n";
            }
            letter = "n";
        }

        private void o(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "o";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "o";
            }
            letter = "o";
        }

        private void p(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "p";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "p";
            }
            letter = "p";
        }

        private void q(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "q";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "q";
            }
            letter = "q";
        }

        private void r(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "r";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "r";
            }
            letter = "r";
        }

        private void s(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "s";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "s";
            }
            letter = "s";
        }

        private void t(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "t";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "t";
            }
            letter = "t";
        }

        private void u(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "u";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "u";
            }
            letter = "u";
        }

        private void v(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "v";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "v";
            }
            letter = "v";
        }

        private void w(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "w";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "w";
            }
            letter = "w";
        }

        private void x(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "x";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "x";
            }
            letter = "x";
        }

        private void y(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "y";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "y";
            }
            letter = "y";
        }

        private void z(object sender, RoutedEventArgs e)
        {
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += "z";
            }
            else
            {
                txtResultaat.Text += "*";
                woord += "z";
            }
            letter = "z";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtResultaat.Text = txtResultaat.Text.Substring(0, txtResultaat.Text.Length - 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtResultaat.Text = String.Empty;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void btnRaad_Click(object sender, RoutedEventArgs e)
        {
            txtLetter.Text = string.Empty;
            geradenWoord += txtResultaat.Text;
            //geradenWoord += geradenWoord.ToLower();
            Compare();
            lblFout.Content = $"Foute:{fout}";
            lblJuist.Content = $"Juiste:{juist}";
            lblLevens.Content = $"{counterr} levens";
            //if (woord != geradenwoord)
            //{
            //    levens -= 1;
            //    lbllevens.content = $"{levens} levens";

            //    txtresultaat.background = brushes.red;
            //    txtresultaat.text = string.empty;
            //    if (levens == 0)
            //    {
            //        lbllevens.visibility = visibility.hidden;
            //        lbljuist.visibility = visibility.hidden;
            //        lblfout.visibility = visibility.hidden;
            //        lblnietgeraden.visibility = visibility.visible;
            //        txtresultaat.background = brushes.white;
            //        window.background = brushes.red;
            //        txtresultaat.visibility = visibility.hidden;
            //        keys.isenabled = false;
            //    }
            //}
            //else if (woord == geradenwoord)
            //{
            //    txtresultaat.background = brushes.lightgreen;
            //    lbllevens.visibility = visibility.hidden;
            //    lbljuist.visibility = visibility.hidden;
            //    lblfout.visibility = visibility.hidden;
            //    lblgeraden.visibility = visibility.visible;
            //    btnraad.isenabled = false;
            //    keys.isenabled = false;
            //}
        }
    }
}
