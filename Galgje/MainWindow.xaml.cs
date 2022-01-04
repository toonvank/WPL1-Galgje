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
using System.Drawing;

namespace Galgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string woord, geradenWoord, juist, fout, letter, lijnen;
        char randomLetter, hintLetter;
        int counter = 1, counterr=10, maxTijd, random, tijdmonitor, moeilijkheidsgraad;
        DispatcherTimer Tikker = new DispatcherTimer();
        bool verberg = false, gelijk = false, knop = false;
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
        private char[] alfabet = new char[]
        {
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z',
        };

        private void KeysTonen()
        {
            //alle keys terug laten tonen na nieuw spel
            a.Visibility = Visibility.Visible;
            b.Visibility = Visibility.Visible;
            c.Visibility = Visibility.Visible;
            d.Visibility = Visibility.Visible;
            e.Visibility = Visibility.Visible;
            f.Visibility = Visibility.Visible;
            g.Visibility = Visibility.Visible;
            h.Visibility = Visibility.Visible;
            i.Visibility = Visibility.Visible;
            j.Visibility = Visibility.Visible;
            k.Visibility = Visibility.Visible;
            l.Visibility = Visibility.Visible;
            m.Visibility = Visibility.Visible;
            n.Visibility = Visibility.Visible;
            o.Visibility = Visibility.Visible;
            p.Visibility = Visibility.Visible;
            q.Visibility = Visibility.Visible;
            r.Visibility = Visibility.Visible;
            s.Visibility = Visibility.Visible;
            t.Visibility = Visibility.Visible;
            u.Visibility = Visibility.Visible;
            v.Visibility = Visibility.Visible;
            w.Visibility = Visibility.Visible;
            x.Visibility = Visibility.Visible;
            y.Visibility = Visibility.Visible;
            z.Visibility = Visibility.Visible;

        }
        private void Hoofdscherm()
        {
            //hoofdscherm doen verdwijen
            igmLogo.Visibility = Visibility.Hidden;
            btnSingle.Visibility = Visibility.Hidden;
            btnMulti.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
            imgLogoaltijdaanwezig.Visibility = Visibility.Visible;
        }

        private void GeefEenWoordIn()
        {
            //scherm waar woord ingegeven wordt tonen
            lblWoord.Visibility = Visibility.Visible;
            txtResultaat.Visibility = Visibility.Visible;
            btnVerberg.Visibility = Visibility.Visible;
            keys.Visibility = Visibility.Visible;
        }

        private void GeefEenWoordInVerberg()
        {
            //scherm waar woord ingegeven wordt tonen
            lblWoord.Visibility = Visibility.Hidden;
            btnVerberg.Visibility = Visibility.Hidden;
        }
        private void Moeilijkheidsgraad()
        {
            string answer = Microsoft.VisualBasic.Interaction.InputBox($"[E]asy - [M]edium - [H]ard - [V]eteran\nVul een letter in\nMedium indien leeg.","Moeilijkheidsgraad");
            if (answer == "e" || answer == "E")
            {
                moeilijkheidsgraad = 21;
                maxTijd = 21;
            }
            else if (answer == "m" || answer == "M")
            {
                moeilijkheidsgraad = 16;
                maxTijd = 16;
            }
            else if (answer == "h" || answer == "H")
            {
                moeilijkheidsgraad = 11;
                maxTijd = 11;
            }
            else if (answer == "v" || answer == "V")
            {
                moeilijkheidsgraad = 6;
                maxTijd = 6;
            }
            else
            {
                moeilijkheidsgraad = 16;
                maxTijd = 16;
            }
        }
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

        private void eindbuttons(string status)
        {
            //dit gebeurd er als speler gewonnen of verloren heeft
            MessageBox.Show(status);
            btnRaad.IsEnabled = false;
            keys.IsEnabled = false;
            Tikker.Stop();
            txtResultaat.Text = String.Empty;
            keys.Visibility = Visibility.Hidden;
            lblLevens.Visibility = Visibility.Hidden;
            lblJuist.Visibility = Visibility.Hidden;
            lblFout.Visibility = Visibility.Hidden;
            lblTimer.Visibility = Visibility.Hidden;
            btnHint.Visibility = Visibility.Hidden;
            btnNieuw.Visibility = Visibility.Visible;
            btnExit2.Visibility = Visibility.Visible;
            lblEindwoord.Content = String.Empty;
            lblEindwoord.Content = woord;
            lblEindwoord.Visibility = Visibility.Visible;
            eindknoppen.Visibility = Visibility.Visible;
            txtResultaat.Visibility = Visibility.Hidden;
            btnRaad.Visibility = Visibility.Hidden;
            counterr = 10;
            stickmanVerdwijn();
        }
        private void Timer()
        {
            window.Background = Brushes.White;
            // Timer laten aflopen om de seconde.
            Tikker.Tick += new EventHandler(DispatcherTimer_Tick);
            Tikker.Interval = new TimeSpan(0, 0, 1);
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
                }
            }
            else
            {
                window.Background = Brushes.Red;
                counterr -= 1;
                lblLevens.Content = $"{counterr} levens";
                lblTimer.Visibility = Visibility.Hidden;
                MessageBox.Show("Tijd is om");
                maxTijd = moeilijkheidsgraad;
                window.Background = Brushes.White;
                if (counterr == 0)
                {
                    Compare();
                }
            }
        }
        private void btnVerberg_Click(object sender, RoutedEventArgs e)
        {
            GeefEenWoordInVerberg();
            tijdmonitor += 1;
            //voorkomt dat meerdere timer instances gestart worden
            if (tijdmonitor==1)
            {
                Timer();
            }
            else
            {
                Tikker.Start();
            }
            verberg = true;
            //raadknop verbergen
            btnRaad.IsEnabled = true;
            //eerste knoppen verbergen
            btnVerberg.Visibility = Visibility.Hidden;
            lblWoord.Visibility = Visibility.Hidden;
            btnHint.Visibility = Visibility.Visible;
            //labels laten tonen
            lblLevens.Visibility = Visibility.Visible;
            lblJuist.Visibility = Visibility.Visible;
            lblFout.Visibility = Visibility.Visible;
            txtResultaat.Text = string.Empty;
            lblTimer.Visibility = Visibility.Visible;
            btnRaad.Visibility = Visibility.Visible;
            //lijntjes genereren
            char[] lijntjes = woord.ToCharArray();
            int lengteLijntjes = lijntjes.Length;
            for (int i = 0; i < lengteLijntjes; i++)
            {
                txtResultaat.Text += "*";
            }
            knop = true;
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
                    eindbuttons($"U heeft verloren. Het juiste woord was {woord}.");
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
            btnRaad.IsEnabled = false;
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
            btnHint.Visibility = Visibility.Hidden;
            btnNieuw.Visibility = Visibility.Hidden;
            lblWoord.Visibility = Visibility.Hidden;
            lblEindwoord.Visibility = Visibility.Hidden;
            btnVerberg.Visibility = Visibility.Hidden;
            igmLogo.Visibility = Visibility.Visible;
            imgLogoaltijdaanwezig.Visibility = Visibility.Hidden;
            eindknoppen.Visibility = Visibility.Hidden;
            btnSingle.Visibility = Visibility.Visible;
            btnMulti.Visibility = Visibility.Visible;
            btnExit.Visibility = Visibility.Visible;



            
            lblJuist.Content = "Juiste:";
            lblFout.Content = "Foute:";

            juist = String.Empty;
            fout = String.Empty;

            
            counterr = 10;
            counter = 1;
            
            lblTimer.Visibility = Visibility.Hidden;
            Tikker.Stop();
            stickmanVerdwijn();
        }


        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_GotMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Moeilijkheidsgraad();
            random = rndGetal.Next(100);
            for (int i = 0; i < 100; i++)
            {
                if (i == random)
                {
                    woord = galgjeWoorden[i];
                    btnVerberg_Click(null, null);
                }
            }
            Hoofdscherm();
            keys.Visibility = Visibility.Visible;
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            Moeilijkheidsgraad();
            Hoofdscherm();
            GeefEenWoordIn();
            KeysTonen();
        }

        private void button(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (knop == true)
            {
                btn.Visibility = Visibility.Hidden;
            }
            else
            {

            }
            
            letter = string.Empty;
            if (verberg == true)
            {
                txtLetter.Text += btn.Name;
            }
            else
            {
                txtResultaat.Text += "*";
                woord += btn.Name;
            }
            letter = btn.Name;
        }

        private void btnHint_Click(object sender, RoutedEventArgs e)
        {
            random = rndGetal.Next(26);
            for (int i = 0; i < alfabet.Length; i++)
            {
                if (i == random)
                {
                    randomLetter = alfabet[i];
                }
            }
            for (int i = 0; i < woord.Length; i++)
            {
                if (woord[i] != randomLetter)
                {
                    hintLetter = randomLetter;
                }
            }
            //trekt een leven af na hint
            lblLevens.Content = String.Empty;
            counterr -= 1;
            lblLevens.Content = $"{counterr} levens";
            MessageBox.Show(Convert.ToString(hintLetter));
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
            lblFout.Content = $"Foute:\n{fout}";
            lblJuist.Content = $"Juiste:{juist}";
            lblLevens.Content = $"{counterr} levens";
            maxTijd = moeilijkheidsgraad;
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
