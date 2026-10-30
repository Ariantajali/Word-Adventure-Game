using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Adventures_in_words
{
    /// <summary>
    /// Interaction logic for Level_Select_Game2.xaml
    /// </summary>
    public partial class Level_Select_Game2 : Window
    {
        Game1_DataAcsess Data2 = new Game1_DataAcsess();
        Game2_DataAcsess Data = new Game2_DataAcsess();
        private const string levelProgressFilePath = "level_progress_game2.txt";
        // Path to the level progress file
        private bool[] levelCompletionStatus = new bool[24]; // Array to store the completion status of each level
        public Level_Select_Game2()
        {           
            InitializeComponent();
            UpdateLevelProgress(); // Check and update the level progress
            btncoin.Content = Data2.ExtractCoin();
            Data.CheckAndCreateFile();
            backgroundMusic.Play();
        }
        private void UpdateLevelProgress()
        {

            int currentLevel = Data.selectlevel();
            // Enable and style the buttons based on the current level
            for (int i = 1; i <= currentLevel; i++)
            {
                Button levelButton = FindName($"btnlvl{i}") as Button;
                if (levelButton != null)
                {
                    levelButton.IsEnabled = true;
                    levelButton.Style = (Style)FindResource("levelupButtonStyle");
                    levelButton.Content = i.ToString();
                }

                // Set the style of the previous buttons to levelupButtonStyle
                for (int j = 1; j < i; j++)
                {
                    Button prevLevelButton = FindName($"btnlvl{j}") as Button;
                    if (prevLevelButton != null)
                    {
                        prevLevelButton.Style = (Style)FindResource("levelupButtonStyle");
                    }
                }
            }

            // Disable and remove content from buttons representing levels higher than the current level
            for (int i = currentLevel + 1; i <= 24; i++)
            {
                Button levelButton = FindName($"btnlvl{i}") as Button;
                if (levelButton != null)
                {
                    levelButton.IsEnabled = false;
                    levelButton.Style = (Style)FindResource("leveloffButtonStyle");
                    levelButton.Content = null;
                }
            }


        }
        private void lvlnext_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            brd1.Visibility = Visibility.Collapsed;
            brd2.Visibility = Visibility.Visible;
        }

        private void lvllast_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            brd2.Visibility = Visibility.Collapsed;
            brd1.Visibility = Visibility.Visible;
        }

        private void btnlvl1_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level1_g2 lvl1 = new Level1_g2();

            lvl1.Show();
            this.Close();

            // Update the level progress when a level is complete
            UpdateLevelProgress();
        }

        private void btnlvl2_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level2_g2 lvl2 = new Level2_g2();

            lvl2.Show();
            this.Close();

            // Update the level progress when a level is complete
            UpdateLevelProgress();
        }

        private void btnlvl3_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level3_g2 lvl3 = new Level3_g2();

            lvl3.Show();
            this.Close();

            // Update the level progress when a level is complete
            UpdateLevelProgress();
        }

        private void Btnmusicon_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            backgroundMusic.Play();
        }

        private void Btnmusicoff_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            backgroundMusic.Stop();
        }

        private void Btnhome_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Menu_Window mnwid = new Menu_Window();
            mnwid.Show();
            this.Close();
        
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
        private void clicksound()
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri("Resources/SoundEffect/mixkit-mouse-click-close-1113.wav", UriKind.Relative));
            player.Play();
        }
    }
}
