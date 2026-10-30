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
using System.Data.OleDb;
using System.Windows.Media.Animation;

namespace Adventures_in_words
{
    /// <summary>
    /// Interaction logic for Level1_g1.xaml
    /// </summary>
    public partial class Level1_g1 : Window
    {
        Game1_DataAcsess Data = new Game1_DataAcsess();
        MediaPlayer player = new MediaPlayer();
        public string currentWord = "";
        public string[] letters;
        public string[] Word;
        public bool[] countwords = new bool[2];
        public string[] newletters;
        public int coinCount;
        public int levelCompletion;
        public int currentlevel=1;
        public Level1_g1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            coinCount = Data.ExtractCoin();
            btncoin.Content = coinCount.ToString();
            letters = Data.GetLettersForLevel(1);
            Word = Data.GetWordsForLevel(1);
            wrd1.Content = letters[0];
            wrd2.Content = letters[1];
            wrd3.Content = letters[2];
            wrd4.Content = letters[3];
            CheckCompletion();


        }

        private void wrd1_Click(object sender, RoutedEventArgs e)
        {
            clicksound();

            if (newletters != null && newletters.Length >= 1)
                currentWord += newletters[0];
            else
                currentWord += letters[0];
            UpdateWordFullButton();
        }

        private void wrd2_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 2)
                currentWord += newletters[1];
            else
                currentWord += letters[1];
            UpdateWordFullButton();
        }

        private void wrd3_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 3)
                currentWord += newletters[2];
            else
                currentWord += letters[2];
            UpdateWordFullButton();
        }

        private void wrd4_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 4)
                currentWord += newletters[3];
            else
                currentWord += letters[3];
            UpdateWordFullButton();
        }
        private void UpdateWordFullButton()
        {
            wordfull.Content = currentWord;
            if (currentWord.Length >= 2)
            {
                bool wordMatched = false;

                for (int i = 0; i < Word.Length; i++)
                {
                    if (Word[i] == currentWord)
                    {
                        // Word matches defined word, apply correct style
                        player.Open(new Uri("Resources/SoundEffect/mixkit-positive-interface-beep-221.wav", UriKind.Relative));
                        player.Play();
                        wordfull.Style = (Style)FindResource("CustomButtonStyleWordfullTrue");

                        if (i == 0)
                        {
                            wrd1_1.Content = Word[0][0];
                            wrd1_2.Content = Word[0][1];
                            wrd1_1.Style = (Style)FindResource("WordT");
                            wrd1_2.Style = (Style)FindResource("WordT");
                            // Update countwords based on your logic
                            countwords[0] = true;
                        }
                        else if (i == 1)
                        {
                            wrd2_1.Content = Word[1][0];
                            wrd2_2.Content = Word[1][1];
                            wrd2_1.Style = (Style)FindResource("WordT");
                            wrd2_2.Style = (Style)FindResource("WordT");
                            // Update countwords based on your logic
                            countwords[1] = true;
                        }

                        wordMatched = true;
                        break;
                    }
                }

                if (!wordMatched)
                {
                    // Word doesn't match any defined words, apply incorrect style
                    player.Open(new Uri("Resources/SoundEffect/mixkit-click-error-1110.wav", UriKind.Relative));
                    player.Play();
                    wordfull.Style = (Style)FindResource("CustomButtonStyleWordfullfalse");
                }

                // Reset current word after 2 seconds
                Task.Delay(2000).ContinueWith(_ =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        wordfull.Style = (Style)FindResource("CustomButtonStyleWordfull");
                        currentWord = "";
                        wordfull.Content = currentWord;
                    });
                });

                CheckCompletion(); // Call the completion check method
            }
        }

        private void CheckCompletion()
        {
            int stat;
            stat = Data.GetTrueLevel(1);
            if (stat == 0)
            {
                if (countwords[0] && countwords[1])
                {
                    coinCount += 30;
                    btncoin.Content = coinCount.ToString();
                    Data.SaveCoin(coinCount);
                    currentlevel++;
                    Data.AddLevel(currentlevel);
                    Data.SetTrueLevel(1);
                    player.Open(new Uri("Resources/SoundEffect/mixkit-melodic-gold-price-2000.wav", UriKind.Relative));
                    player.Play();
                    MessageBox.Show("Mission Complete.");
                    Level_Select lvls = new Level_Select();
                    lvls.Show();
                    this.Close();
                }
            }
            else
            {
                if (countwords[0] && countwords[1])
                {
                    player.Open(new Uri("Resources/SoundEffect/mixkit-ethereal-fairy-win-sound-2019.wav", UriKind.Relative));
                    player.Play();
                    MessageBox.Show("Mission Complete.");
                    Level_Select lvls = new Level_Select();
                    lvls.Show();
                    this.Close();
                }
            }
        
            
                  
        }

        private void btngiuld_Click(object sender, RoutedEventArgs e)
        {
            player.Open(new Uri("Resources/SoundEffect/mixkit-coins-handling-1939.wav", UriKind.Relative));
            player.Play();
            if (coinCount >= 15)
            {
                

                if (wrd1_1.Content == null)
                {
                    wrd1_1.Content = Word[0][0];
                    coinCount -= 15;
                    btncoin.Content = coinCount.ToString();
                    Data.SaveCoin(coinCount);
                }
                else if (wrd1_2.Content == null)
                {
                    wrd1_2.Content = Word[0][1];
                    coinCount -= 15;
                    btncoin.Content = coinCount.ToString();
                    Data.SaveCoin(coinCount);
                }
                else if (wrd2_1.Content == null)
                {
                    wrd2_1.Content = Word[1][0];
                    coinCount -= 15;
                    btncoin.Content = coinCount.ToString();
                    Data.SaveCoin(coinCount);
                }
                else if (wrd2_2.Content == null)
                {
                    wrd2_2.Content = Word[1][1];
                    coinCount -= 15;
                    btncoin.Content = coinCount.ToString();
                    Data.SaveCoin(coinCount);
                }
            }
            else
            {
                MessageBox.Show("Not enough coins.");
            }
        }


        private void btnRotation_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            // Shuffling the letters array
            newletters = ShuffleArray(letters);

            // Assigning the shuffled values to the buttons
            wrd1.Content = newletters[0];
            wrd2.Content = newletters[1];
            wrd3.Content = newletters[2];
            wrd4.Content = newletters[3];
        }

        private string[] ShuffleArray(string[] array)
        {
            Random random = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return array;
        }

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (Dock1.Visibility == Visibility.Collapsed)
            {
                // Show animation
                Dock1.Visibility = Visibility.Visible;
                DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));
                Dock1.BeginAnimation(OpacityProperty, fadeInAnimation);
            }
            else
            {
                // Hide animation
                DoubleAnimation fadeOutAnimation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.3));
                fadeOutAnimation.Completed += (s, _) => Dock1.Visibility = Visibility.Collapsed;
                Dock1.BeginAnimation(OpacityProperty, fadeOutAnimation);
            }
        }

        private void Btnhome_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level_Select lvlwn = new Level_Select();
            lvlwn.Show();
            this.Close();

        }
        public void clicksound()
        {
            player.Open(new Uri("Resources/SoundEffect/mixkit-mouse-click-close-1113.wav", UriKind.Relative));
            player.Play();
        }
    }

}

