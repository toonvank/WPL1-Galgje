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
using System.Drawing.Drawing2D;

namespace Galgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// AllowsTransparency="True" aan top van xaml normaal actief, maar dat maakt het niet mogelijk om scaling te testen. zorgt ervoor dat witte bar tevoorschijn komt
    public partial class MainWindow : Window
    {
        #region
        //variabelen
        string woord, geradenWoord, juist, fout, letter, lijnen, spelerNaam, modusChecker;
        char randomLetter, hintLetter;
        int galgCounter = 1, levensCounter=10, maxTijd, random, tijdmonitor, moeilijkheidsgraad, spelerCount = 0, hintCounter = 0, hintMoeilijkheid;
        DispatcherTimer Tikker = new DispatcherTimer();
        bool verbergChecker = false, gelijk = false, verbergKnopChecker = false, hintMogelijk = true, spelGespeeld = false, moeilijkheid = true, scoreboardChecker = false, tienbug= false, letteringegeven = false, welOpScorebord = false;
        Random rndGetal = new Random();
        List<string> naam = new List<string>();
        List<int> score = new List<int>();
        List<string> tijd = new List<string>();
        List<string> spelers = new List<string>();
        List<string> spelersTop = new List<string>();
        private string[] galgjeWoorden = new string[]
        {
            "grafeem","tjiftjaf","maquette","kitsch","pochet","convocaat","jakkeren","collaps","zuivel","cesium","voyant","spitten","pancake","gietlepel","karwats","dehydreren",
            "viswijf","flater","cretonne","sennhut","tichel","wijten","cadeau","trotyl","chopper","pielen","vigeren", "vrijuit","dimorf","kolchoz","janhen","plexus","borium","ontweien","quiche","ijverig","mecenaat","falset", "telexen","hieruit", "femelaar","cohesie","exogeen","plebejer","opbouw", "zodiak", "volder","vrezen", "convex","verzenden", "ijstijd","fetisj","gerekt", "necrose","conclaaf","clipper","poppetjes","looikuip","hinten",
            "inbreng", "arbitraal","dewijl","kapzaag","welletjes","bissen","catgut","oxymoron","heerschaar","ureter","kijkbuis","dryade","grofweg", "laudanum","excitatie","revolte","heugel","geroerd","hierbij","glazig","pussen", "liquide","aquarium", "formol","kwelder","zwager","vuldop","halfaap", "hansop", "windvaan","bewogen","vulstuk","efemeer","decisief","omslag","prairie", "schuit","weivlies","ontzeggen","schijn","sousafoon"
        };
        private char[] alfabet = new char[]
        {
            //alfabet voor hint
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        };
        #endregion

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
            spelGespeeld = true;
            moeilijkheid = false;
            hintMogelijk = false;
            lblNaam.Visibility = Visibility.Hidden;
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
            //scherm waar woord ingegeven wordt verbergen
            lblWoord.Visibility = Visibility.Hidden;
            btnVerberg.Visibility = Visibility.Hidden;
        }

        private void lblNaam_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Hangman\n2021 - Made by Toon Van Kimmenade \nPXL 1PROG");
        }

        private void Moeilijkheidsgraad()
        {
            //moeilijkheidsgraad kiezen
            string answer = Microsoft.VisualBasic.Interaction.InputBox($"[E]asy - [M]edium - [H]ard - [V]eteran\nVul een letter in","Moeilijkheidsgraad","m");
            if (answer == "e" || answer == "E")
            {
                moeilijkheidsgraad = 21;
                maxTijd = 21;
                hintMoeilijkheid = 11;
            }
            else if (answer == "m" || answer == "M")
            {
                moeilijkheidsgraad = 16;
                maxTijd = 16;
                hintMoeilijkheid = 6;
            }
            else if (answer == "h" || answer == "H")
            {
                moeilijkheidsgraad = 11;
                maxTijd = 11;
                hintMoeilijkheid = 4;
            }
            else if (answer == "v" || answer == "V")
            {
                moeilijkheidsgraad = 6;
                maxTijd = 6;
                hintMoeilijkheid = 2;
            }
            else
            {
                moeilijkheidsgraad = 16;
                maxTijd = 16;
                hintMoeilijkheid = 5;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            txtBack.Opacity = 0.745;

            //standaard txtHighscore waarde
            txtHighscore.Text += $"Er zijn nog geen highscores beschikbaar.";
            txtHighscore_Copy.Text += $"Er zijn nog geen highscores beschikbaar.";
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
            txtHighscore.Visibility = Visibility.Visible;
            eindknoppen.Visibility = Visibility.Visible;
            txtResultaat.Visibility = Visibility.Hidden;
            btnRaad.Visibility = Visibility.Hidden;
            stckRaad.Visibility = Visibility.Hidden;
            imgLogoaltijdaanwezig.Visibility = Visibility.Hidden;
            stckEindwoord.Visibility = Visibility.Visible;
            if (btnSingle.Visibility == Visibility.Visible)
            {
                //dit zorgt ervoor dat niet onnodig extra spelers gecreëerd worden indien gebruiker zich op hoofdscherm bevind
            }
            else
            {
                spelerCount++;
            }
            stickmanVerdwijn();
        }
        private void Timer()
        {
            // Timer laten aflopen om de seconde.
            Tikker.Tick += new EventHandler(DispatcherTimer_Tick);
            Tikker.Interval = new TimeSpan(0, 0, 1);
            Tikker.Start();
            lblTimer.Content = maxTijd;
        }

        private void MnuHighscore_MouseEnter(object sender, MouseEventArgs e)
        {
            if (stckEindwoord.Visibility == Visibility.Hidden)//highscore wordt niet getoond op eindscherm
            {
                if (spelGespeeld == true)
                {
                    txtHighscore_Copy.Visibility = Visibility.Visible;
                }
            }
            
            
        }

        private void MnuToetsen_Click(object sender, RoutedEventArgs e)
        {
            if (keys.Visibility == Visibility.Visible)
            {
                KeysTonen();
            }
            else
            {
                MessageBox.Show("U kan enkel alle toesten tonen als het toestenbord aanwezig is.");
            }
            
        }

        private void MnuHighscore_Click(object sender, RoutedEventArgs e)
        {
            if (spelGespeeld == false)
            {
                MessageBox.Show("Er zijn nog geen highscores aanwezig.");
            }
            
        }

        private void Difficulty_Click(object sender, RoutedEventArgs e)
        {
            if (moeilijkheid == true)
            {
                Moeilijkheidsgraad();
            }
            else
            {
                MessageBox.Show("U kan de moelijkheidsgraad niet tijdens het spel veranderen. Start een nieuw spel en probeer dan opnieuw.");
            }
            
        }

        private void MnuHighscore_MouseLeave(object sender, MouseEventArgs e)
        {
            if (stckEindwoord.Visibility != Visibility.Visible) //zorgt ervoor dat txt highscore niet verdwijnt op eindscherm
            {
                txtHighscore_Copy.Visibility = Visibility.Hidden;
                if (spelGespeeld == false)
                {
                    txtHighscore.Text = $"Highscore";
                    txtHighscore_Copy.Text = $"Highscore";
                }
            }
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
                txtBack.Visibility = Visibility.Visible;
                levensCounter -= 1;
                lblLevens.Content = $"{levensCounter} levens";
                lblTimer.Visibility = Visibility.Hidden;
                MessageBox.Show("Tijd is om");
                maxTijd = moeilijkheidsgraad;
                txtBack.Visibility = Visibility.Hidden; //background remove
                if (levensCounter == 0)
                {
                    Compare();
                }
            }
        }
        private void btnVerberg_Click(object sender, RoutedEventArgs e)
        {
            if (txtResultaat.Text == string.Empty & modusChecker == "multi")
            {
                MessageBox.Show("Geef een woord in.");
            }
            else
            {
                GeefEenWoordInVerberg();
                tijdmonitor += 1;
                //voorkomt dat meerdere timer instances gestart worden
                if (tijdmonitor == 1)
                {
                    Timer();
                }
                else
                {
                    Tikker.Start();
                }
                verbergChecker = true;
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
                stckRaad.Visibility = Visibility.Visible;
                //sterren genereren
                char[] lijntjes = woord.ToCharArray();
                int lengteLijntjes = lijntjes.Length;
                for (int i = 0; i < lengteLijntjes; i++)
                {
                    txtResultaat.Text += "*";
                }
                verbergKnopChecker = true;
            }
        }
        private void ScoreGeordend()
        {
            //score geordend op levens
            string time = DateTime.Now.ToString("hh:mm:ss");
            if (levensCounter == 10)
            {
                //oplossing voor bug waar 10 altijd na sorteren onder aan de lijst stond
                tienbug = true;
                spelersTop.Add($"\n\t   {levensCounter}   -   {spelerNaam}   {time}");
            }
            else
            {
                spelers.Add($"\n\t   {levensCounter}   -   {spelerNaam}   {time}");
            }
            txtHighscore.Text = string.Empty;
            txtHighscore.Text = $"Highscore\n";
            txtHighscore_Copy.Text = $"Highscore\n";
            spelers.Sort();
            spelers.Reverse();
            if (tienbug == true)
            {
                for (int i = 0; i < spelersTop.Count; i++)
                {
                    txtHighscore.Text += $"{spelersTop[i]}";
                    txtHighscore_Copy.Text += $"{spelersTop[i]}";
                }
                for (int i = 0; i < spelers.Count; i++)
                {
                    txtHighscore.Text += $"{spelers[i]}";
                    txtHighscore_Copy.Text += $"{spelers[i]}";
                }
            }
            else
            {
                for (int i = 0; i < spelers.Count; i++)
                {
                    txtHighscore.Text += $"{spelers[i]}";
                    txtHighscore_Copy.Text += $"{spelers[i]}";
                }
            }
        }
        private void ScoreOngeordend()
        {
            string time = DateTime.Now.ToString("hh:mm:ss");
            naam.Add(spelerNaam);
            score.Add(levensCounter);
            tijd.Add(time);
            //txtHighscore.Text += $"\n\t   {spelerNaam}   -   {levensCounter}   ({time})";
            //txtHighscore_Copy.Text += $"\n\t   {spelerNaam}   -   {levensCounter}   ({time})";
            txtHighscore.Text = string.Empty;
            txtHighscore.Text = $"Highscore\n";
            txtHighscore_Copy.Text = $"Highscore\n";
            for (int i = 0; i < naam.Count; i++)
            {
                txtHighscore.Text += $"{naam[i]}   -   {score[i]}   ({tijd[i]})\n";
                txtHighscore_Copy.Text += $"{naam[i]}   -   {score[i]}   ({tijd[i]})\n";
            }
        }
        private void Highscore()
        {
            string currentPlayer = $"Speler {spelerCount}";
            if (scoreboardChecker == false)
            {
                spelerNaam = Microsoft.VisualBasic.Interaction.InputBox($"Vul uw naam in.", "Highscore", currentPlayer);
                //ScoreGeordend();
                ScoreOngeordend();
            }
            else if (welOpScorebord == true)
            {
                spelerNaam = Microsoft.VisualBasic.Interaction.InputBox($"Vul uw naam in.", "Highscore", currentPlayer);
                //ScoreGeordend();
                ScoreOngeordend();
            }
            else
            {
                MessageBox.Show("U heeft een hint gebruikt en komt hierdoor niet op het scoreboard.");
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
                //stickman tonen op basis van levens
                fout += letter;
                switch (galgCounter)
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
                galgCounter++;
                levensCounter--;
                if (levensCounter ==0)
                {
                    txtBack.Visibility = Visibility.Visible;
                    txtBack.Background = Brushes.Red;
                    eindbuttons($"U heeft verloren. Het juiste woord was {woord}.");
                    verloren.Visibility = Visibility.Visible;
                    Highscore();
                    txtBack.Visibility = Visibility.Hidden;
                }
            }
            if (txtResultaat.Text == woord)
            {
                Tikker.Stop();
                txtBack.Visibility = Visibility.Visible;
                txtBack.Background = Brushes.Green;
                eindbuttons($"U heeft het woord {woord} geraden!");
                gewonnen.Visibility = Visibility.Visible;
                Highscore();
                txtBack.Visibility = Visibility.Hidden;
            }
        }
        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            txtBack.Visibility = Visibility.Hidden;
            txtBack.Background = Brushes.Red;
            btnRaad.IsEnabled = false;
            verbergChecker = false;
            keys.IsEnabled = true;
            woord = string.Empty;
            geradenWoord = string.Empty;
            txtResultaat.Text = string.Empty;
            txtLetter.Text = string.Empty;
            moeilijkheid = true;
            spelGespeeld = true;
            scoreboardChecker = false;
            hintMogelijk = true;
            letteringegeven = false;
            hintCounter = 0;

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
            txtHighscore.Visibility = Visibility.Hidden;
            btnVerberg.Visibility = Visibility.Hidden;
            igmLogo.Visibility = Visibility.Visible;
            imgLogoaltijdaanwezig.Visibility = Visibility.Hidden;
            eindknoppen.Visibility = Visibility.Hidden;
            btnSingle.Visibility = Visibility.Visible;
            btnMulti.Visibility = Visibility.Visible;
            btnExit.Visibility = Visibility.Visible;
            keys.Visibility = Visibility.Hidden;
            btnRaad.Visibility = Visibility.Hidden;
            stckRaad.Visibility = Visibility.Hidden;
            verloren.Visibility = Visibility.Hidden;
            gewonnen.Visibility = Visibility.Hidden;
            stckEindwoord.Visibility = Visibility.Hidden;
            spelerNaam = String.Empty; //naam leegmaken
            welOpScorebord = false;
            lblNaam.Visibility = Visibility.Visible;


            lblJuist.Content = "Juist:";
            lblFout.Content = "Fout:";
            modusChecker = String.Empty;

            juist = String.Empty;
            fout = String.Empty;

            
            levensCounter = 10;
            galgCounter = 1;
            
            lblTimer.Visibility = Visibility.Hidden;
            Tikker.Stop();
            stickmanVerdwijn();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            modusChecker = "single";
            //btnSingle
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
            KeysTonen();
            stckRaad.Visibility = Visibility.Visible;
            txtResultaat.Visibility = Visibility.Visible;
            
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            modusChecker = "multi";
            Moeilijkheidsgraad();
            Hoofdscherm();
            GeefEenWoordIn();
            KeysTonen();
            verbergKnopChecker = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            Button btn = (Button)sender;
            if (verbergKnopChecker == true)//enkel als woord al ingegeven is
            {
                letteringegeven = true;
                btn.Visibility = Visibility.Hidden;//wegvallen van knoppen na druk
            }
            
            letter = string.Empty;
            if (verbergChecker == true)
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
            scoreboardChecker = true;
            if (hintMogelijk == true)
            {
                MessageBox.Show("U kan enkel een hint opvragen tijdens het spel.");
            }
            else
            {
                try
                {
                    if (letteringegeven == true)
                    {
                        hintCounter++;
                        if (hintCounter < hintMoeilijkheid)
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
                            MessageBox.Show(Convert.ToString(hintLetter));
                        }
                        else
                        {
                            MessageBox.Show($"U heeft het maximum aantal hints ({hintMoeilijkheid - 1}) gebruikt.");
                        }
                        //trekt een leven af na hint
                        /*
                        lblLevens.Content = String.Empty;
                        levensCounter -= 1;
                        lblLevens.Content = $"{levensCounter} levens";
                        */
                    }
                    else if (letteringegeven == false)
                    {
                        MessageBox.Show("Druk eerst op een letter.");
                        welOpScorebord = true;// als dit niet uitgevoerd werd zou gebruiker niet op scoreboard komen terwijl deze geen hint gebruikt heeft
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("U kan enkel een hint opvragen tijdens het spel.");
                }
            }
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
            if (letteringegeven == true)
            {
                txtLetter.Text = string.Empty;
                geradenWoord += txtResultaat.Text;
                //geradenWoord += geradenWoord.ToLower();
                Compare();
                lblFout.Content = $"Foute:\n{fout}";
                lblJuist.Content = $"Juiste:{juist}";
                lblLevens.Content = $"{levensCounter} levens";
                maxTijd = moeilijkheidsgraad;
            }
            else if (letteringegeven == false)
            {
                MessageBox.Show("Druk eerst op een letter.");
            }

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
