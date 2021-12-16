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
using System.Windows.Threading;

namespace Galgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string woord, geradenWoord, juist, fout, letter, lijnen;
        int counter = 1, counterr=10, maxTijd=11, random;
        DispatcherTimer Tikker = new DispatcherTimer();
        bool verberg = false, gelijk = false;
        Random rndGetal = new Random();

        private string[] galgjeWoorden = new string[]
        {
            "grafeem",
            "tjiftjaf",
            "maquette",
            "kitsch",
            "pochet",
            "convocaat",
            "jakkeren",
            "collaps",
            "zuivel",
            "cesium",
            "voyant",
            "spitten",
            "pancake",
            "gietlepel",
            "karwats",
            "dehydreren",
            "viswijf",
            "flater",
            "cretonne",
            "sennhut",
            "tichel",
            "wijten",
            "cadeau",
            "trotyl",
            "chopper",
            "pielen",
            "vigeren",
            "vrijuit",
            "dimorf",
            "kolchoz",
            "janhen",
            "plexus",
            "borium",
            "ontweien",
            "quiche",
            "ijverig",
            "mecenaat",
            "falset",
            "telexen",
            "hieruit",
            "femelaar",
            "cohesie",
            "exogeen",
            "plebejer",
            "opbouw",
            "zodiak",
            "volder",
            "vrezen",
            "convex",
            "verzenden",
            "ijstijd",
            "fetisj",
            "gerekt",
            "necrose",
            "conclaaf",
            "clipper",
            "poppetjes",
            "looikuip",
            "hinten",
            "inbreng",
            "arbitraal",
            "dewijl",
            "kapzaag",
            "welletjes",
            "bissen",
            "catgut",
            "oxymoron",
            "heerschaar",
            "ureter",
            "kijkbuis",
            "dryade",
            "grofweg",
            "laudanum",
            "excitatie",
            "revolte",
            "heugel",
            "geroerd",
            "hierbij",
            "glazig",
            "pussen",
            "liquide",
            "aquarium",
            "formol",
            "kwelder",
            "zwager",
            "vuldop",
            "halfaap",
            "hansop",
            "windvaan",
            "bewogen",
            "vulstuk",
            "efemeer",
            "decisief",
            "omslag",
            "prairie",
            "schuit",
            "weivlies",
            "ontzeggen",
            "schijn",
            "sousafoon"
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void stickmanVerdwijn()
        {
            //Dit zorgt ervoor dat de stickman verwijnt
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

        private void letterMethod(string gekozenLetter)
        {
            //deze wordt opgeroepen als een er op een letter van het virtueel toestenbord gedrukt wordt
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += gekozenLetter;
            }
            else
            {
                txtResultaat.Text += "*";
                woord += gekozenLetter;
            }
            letter = gekozenLetter;
        }

        private void eindbuttons(string status)
        {
            //dit gebeurd er als speler gewonnen of verloren heeft
            MessageBox.Show(status);
            btnRaad.IsEnabled = false;
            keys.IsEnabled = false;
            Tikker.Stop();
            txtResultaat.Text = String.Empty;
            lblLevens.Visibility = Visibility.Hidden;
            lblJuist.Visibility = Visibility.Hidden;
            lblFout.Visibility = Visibility.Hidden;
            lblTimer.Visibility = Visibility.Hidden;
            counterr = 10;
            stickmanVerdwijn();
        }
        private void Timer()
        {
            window.Background = Brushes.White;
            // Timer laten aflopen om de seconde.
            Tikker.Tick += new EventHandler(DispatcherTimer_Tick);
            Tikker.Interval = new TimeSpan(0, 0, 1);
            maxTijd = 11;
            Tikker.Start();
            lblTimer.Content = maxTijd;
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (maxTijd != 0)
            {
                lblTimer.Visibility = Visibility.Visible;
                if (txtLetter.Text == String.Empty)
                {
                    maxTijd -= 1;
                    lblTimer.Content = maxTijd;
                }
                else
                {
                    lblTimer.Visibility = Visibility.Hidden;
                    maxTijd = 11;
                }
            }
            else
            {
                window.Background = Brushes.Red;
                counterr -= 1;
                lblLevens.Content = $"{counterr} levens";
                lblTimer.Visibility = Visibility.Hidden;
                maxTijd = 11;
                MessageBox.Show("Tijd is om");
                window.Background = Brushes.White;
                if (counterr == 0)
                {
                    Compare();
                }
            }
        }
        private void btnVerberg_Click(object sender, RoutedEventArgs e)
        {
            Timer();
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
                txtResultaat.Text += "*";
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
                    window.Background = Brushes.Red;
                    eindbuttons($"U heeft verloren. Het juiste woord was {woord}");
                }
            }
            if (txtResultaat.Text == woord)
            {
                Tikker.Stop();
                window.Background = Brushes.Green;
                eindbuttons($"U heeft het woord {woord} geraden!");
            }
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            window.Background = Brushes.White;
            btnRaad.IsEnabled = true;
            verberg = false;
            keys.IsEnabled = true;
            woord = string.Empty;
            geradenWoord = string.Empty;
            txtResultaat.Text = string.Empty;
            txtLetter.Text = string.Empty;

            lblNietGeraden.Visibility = Visibility.Hidden;
            lblGeraden.Visibility = Visibility.Hidden;
            lblLevens.Visibility = Visibility.Hidden;
            lblJuist.Visibility = Visibility.Hidden;
            lblFout.Visibility = Visibility.Hidden;
            txtLetter.Visibility = Visibility.Hidden;
            lblWoord.Visibility = Visibility.Visible;
            btnVerberg.Visibility = Visibility.Visible;
            rndSingle.Visibility = Visibility.Visible;



            txtResultaat.Background = Brushes.White;
            txtLetter.Background = Brushes.White;
            
            lblJuist.Content = "Juiste:";
            lblFout.Content = "Foute:";

            juist = String.Empty;
            fout = String.Empty;

            
            counterr = 10;
            counter = 1;
            maxTijd = 11;
            lblTimer.Visibility = Visibility.Hidden;
            rndSingle.IsChecked = false;
            Tikker.Stop();
            stickmanVerdwijn();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            letterMethod("a");
        }

        private void b(object sender, RoutedEventArgs e)
        {
            letterMethod("b");
        }

        private void c(object sender, RoutedEventArgs e)
        {
            letterMethod("c");
        }

        private void d(object sender, RoutedEventArgs e)
        {
            letterMethod("d");
        }

        private void e(object sender, RoutedEventArgs e)
        {
            letterMethod("e");
        }

        private void f(object sender, RoutedEventArgs e)
        {
            letterMethod("f");
        }

        private void g(object sender, RoutedEventArgs e)
        {
            letterMethod("g");
        }

        private void h(object sender, RoutedEventArgs e)
        {
            letterMethod("h");
        }

        private void i(object sender, RoutedEventArgs e)
        {
            letterMethod("i");
        }

        private void j(object sender, RoutedEventArgs e)
        {
            letterMethod("j");
        }

        private void k(object sender, RoutedEventArgs e)
        {
            letterMethod("k");
        }

        private void l(object sender, RoutedEventArgs e)
        {
            letterMethod("l");
        }

        private void m(object sender, RoutedEventArgs e)
        {
            letterMethod("m");
        }

        private void n(object sender, RoutedEventArgs e)
        {
            letterMethod("n");
        }

        private void o(object sender, RoutedEventArgs e)
        {
            letterMethod("o");
        }

        private void p(object sender, RoutedEventArgs e)
        {
            letterMethod("p");
        }

        private void q(object sender, RoutedEventArgs e)
        {
            letterMethod("q");
        }

        private void r(object sender, RoutedEventArgs e)
        {
            letterMethod("r");
        }

        private void s(object sender, RoutedEventArgs e)
        {
            letterMethod("s");
        }

        private void t(object sender, RoutedEventArgs e)
        {
            letterMethod("t");
        }

        private void u(object sender, RoutedEventArgs e)
        {
            letterMethod("u");
        }


        private void v(object sender, RoutedEventArgs e)
        {
            letterMethod("v");
        }

        private void rndSingle_Checked(object sender, RoutedEventArgs e)
        {
            random = rndGetal.Next(100);
            for (int i = 0; i < 100; i++)
            {
                if (i == random)
                {
                    woord = galgjeWoorden[i];
                    btnVerberg_Click(null, null);
                    rndSingle.Visibility = Visibility.Hidden;
                }
            }
        }

        private void w(object sender, RoutedEventArgs e)
        {
            letterMethod("w");
        }

        private void x(object sender, RoutedEventArgs e)
        {
            letterMethod("x");
        }

        private void y(object sender, RoutedEventArgs e)
        {
            letterMethod("y");
        }

        private void z(object sender, RoutedEventArgs e)
        {
            letterMethod("z");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //backspace knop die niet meer bestaat
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

            //oude methode om volledig woord te vergelijken

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
