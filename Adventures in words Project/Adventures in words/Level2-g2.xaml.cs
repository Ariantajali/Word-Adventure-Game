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
    /// Interaction logic for Level2_g2.xaml
    /// </summary>
    public partial class Level2_g2 : Window
    {
        Game1_DataAcsess Data2 = new Game1_DataAcsess();
        Game2_DataAcsess Data = new Game2_DataAcsess();
        Random r = new Random();
        MediaPlayer player = new MediaPlayer();
        public string currentWord = "";
        public string[] letters;
        public string[] Word;
        public bool[] countwords = new bool[1];
        public string[] newletters;
        public int coinCount;
        public int levelCompletion;
        public int currentlevel = 2;
        public int pointtime = 5;
        public int strLength;
        public Level2_g2()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            coinCount = Data2.ExtractCoin();
            btncoin.Content = coinCount.ToString();
            int ran = RandomNumberGenerator.GenerateUniqueRandomNumber(1, 3);
            if (ran == 1)
            {
                brdpic.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Game2/Pic1.png")));
                strLength = 5;
            }
            else if (ran == 2)
            {
                brdpic.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Game2/Pic2.png")));
                strLength = 5;
            }
            else if (ran == 3)
            {
                brdpic.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Game2/Pic3.png")));
                strLength = 3;
            }
            letters = Data.GetLettersForLevel(ran);
            Word = Data.GetWordsForLevel(ran);
            wrd1.Content = letters[0];
            wrd2.Content = letters[1];
            wrd3.Content = letters[2];
            wrd4.Content = letters[3];
            wrd5.Content = letters[4];
            wrd6.Content = letters[5];
            wrd7.Content = letters[6];
            wrd8.Content = letters[7];
            wrd9.Content = letters[8];
            wrd10.Content = letters[9];
            CheckCompletion();
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
            Level_Select_Game2 lvlwn = new Level_Select_Game2();
            lvlwn.Show();
            this.Close();
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
            wrd5.Content = newletters[4];
            wrd6.Content = newletters[5];
            wrd7.Content = newletters[6];
            wrd8.Content = newletters[7];
            wrd9.Content = newletters[8];
            wrd10.Content = newletters[9];
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

        private void wrd5_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 5)
                currentWord += newletters[4];
            else
                currentWord += letters[4];
            UpdateWordFullButton();
        }

        private void wrd6_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 6)
                currentWord += newletters[5];
            else
                currentWord += letters[5];
            UpdateWordFullButton();
        }

        private void wrd7_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 7)
                currentWord += newletters[6];
            else
                currentWord += letters[6];
            UpdateWordFullButton();
        }

        private void wrd8_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 8)
                currentWord += newletters[7];
            else
                currentWord += letters[7];
            UpdateWordFullButton();
        }

        private void wrd9_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 9)
                currentWord += newletters[8];
            else
                currentWord += letters[8];
            UpdateWordFullButton();
        }

        private void wrd10_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (newletters != null && newletters.Length >= 10)
                currentWord += newletters[9];
            else
                currentWord += letters[9];
            UpdateWordFullButton();
        }
        private void UpdateWordFullButton()
        {
            wordfull.Content = currentWord;
            if (currentWord.Length >= strLength)
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
                            countwords[0] = true;
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
                    pointtime -= 1;
                    if (pointtime == 4)
                    {
                        timepoint.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Game2/t2.png")));

                    }
                    else if (pointtime == 3)
                    {
                        timepoint.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Game2/t3.png")));
                    }
                    else if (pointtime == 2)
                    {
                        timepoint.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Game2/t4.png")));
                    }
                    else if (pointtime == 1)
                    {
                        timepoint.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/Game2/t5.png")));

                    }

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
            stat = Data.GetTrueLevel(2);
            if (stat == 0)
            {
                if (pointtime == 5)
                {
                    if (countwords[0])
                    {
                        coinCount += 50;
                        btncoin.Content = coinCount.ToString();
                        Data2.SaveCoin(coinCount);
                        currentlevel++;
                        Data.AddLevel(currentlevel);
                        Data.SetTrueLevel(2);
                        player.Open(new Uri("Resources/SoundEffect/mixkit-melodic-gold-price-2000.wav", UriKind.Relative));
                        player.Play();
                        MessageBox.Show("Mission Complete.");
                        Level_Select_Game2 lvls = new Level_Select_Game2();
                        lvls.Show();
                        this.Close();
                    }
                }
                else if (pointtime == 4)
                {
                    if (countwords[0])
                    {
                        coinCount += 40;
                        btncoin.Content = coinCount.ToString();
                        Data2.SaveCoin(coinCount);
                        currentlevel++;
                        Data.AddLevel(currentlevel);
                        Data.SetTrueLevel(2);
                        player.Open(new Uri("Resources/SoundEffect/mixkit-melodic-gold-price-2000.wav", UriKind.Relative));
                        player.Play();
                        MessageBox.Show("Mission Complete.");
                        Level_Select_Game2 lvls = new Level_Select_Game2();
                        lvls.Show();
                        this.Close();
                    }
                }
                else if (pointtime == 3)
                {
                    if (countwords[0])
                    {
                        coinCount += 30;
                        btncoin.Content = coinCount.ToString();
                        Data2.SaveCoin(coinCount);
                        currentlevel++;
                        Data.AddLevel(currentlevel);
                        Data.SetTrueLevel(2);
                        player.Open(new Uri("Resources/SoundEffect/mixkit-melodic-gold-price-2000.wav", UriKind.Relative));
                        player.Play();
                        MessageBox.Show("Mission Complete.");
                        Level_Select_Game2 lvls = new Level_Select_Game2();
                        lvls.Show();
                        this.Close();
                    }
                }
                else if (pointtime == 2)
                {
                    if (countwords[0])
                    {
                        coinCount += 20;
                        btncoin.Content = coinCount.ToString();
                        Data2.SaveCoin(coinCount);
                        currentlevel++;
                        Data.AddLevel(currentlevel);
                        Data.SetTrueLevel(2);
                        player.Open(new Uri("Resources/SoundEffect/mixkit-melodic-gold-price-2000.wav", UriKind.Relative));
                        player.Play();
                        MessageBox.Show("Mission Complete.");
                        Level_Select_Game2 lvls = new Level_Select_Game2();
                        lvls.Show();
                        this.Close();
                    }
                }
                else if (pointtime <= 1)
                {
                    if (countwords[0])
                    {
                        coinCount += 10;
                        btncoin.Content = coinCount.ToString();
                        Data2.SaveCoin(coinCount);
                        currentlevel++;
                        Data.AddLevel(currentlevel);
                        Data.SetTrueLevel(2);
                        player.Open(new Uri("Resources/SoundEffect/mixkit-melodic-gold-price-2000.wav", UriKind.Relative));
                        player.Play();
                        MessageBox.Show("Mission Complete.");
                        Level_Select_Game2 lvls = new Level_Select_Game2();
                        lvls.Show();
                        this.Close();
                    }
                }

            }
            else
            {
                if (countwords[0])
                {
                    player.Open(new Uri("Resources/SoundEffect/mixkit-ethereal-fairy-win-sound-2019.wav", UriKind.Relative));
                    player.Play();
                    MessageBox.Show("Mission Complete.");
                    Level_Select_Game2 lvls = new Level_Select_Game2();
                    lvls.Show();
                    this.Close();
                }
            }
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
        public void clicksound()
        {
            player.Open(new Uri("Resources/SoundEffect/mixkit-mouse-click-close-1113.wav", UriKind.Relative));
            player.Play();
        }
    }
    }
