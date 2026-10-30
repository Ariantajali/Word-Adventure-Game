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
    /// Interaction logic for Level_Select.xaml
    /// </summary>
    public partial class Level_Select : Window
    {
        Game1_DataAcsess Data = new Game1_DataAcsess();
        public Level_Select()
        {
            InitializeComponent();
            UpdateLevelProgress(); 
            btncoin.Content = Data.ExtractCoin();
            Data.CheckAndCreateFile();
            backgroundMusic.Play();
        }

        private void UpdateLevelProgress()
        {

            int currentLevel = Data.selectlevel();
            
            for (int i = 1; i <= currentLevel; i++)
            {
                Button levelButton = FindName($"btnlvl{i}") as Button;
                if (levelButton != null)
                {
                    levelButton.IsEnabled = true;
                    levelButton.Style = (Style)FindResource("levelupButtonStyle");
                    levelButton.Content = i.ToString();
                }

            }            
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

        private void btnlvl1_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level1_g1 lvl1 = new Level1_g1();

                lvl1.Show();
                this.Close();

                
                UpdateLevelProgress();
            
        }

        private void btnlvl2_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level2_g1 lvl2 = new Level2_g1();
            lvl2.Show();
            this.Close();

            
            UpdateLevelProgress();
        }
        private void btnlvl3_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level3_g1 lvl3 = new Level3_g1();
            lvl3.Show();
            this.Close();

            
            UpdateLevelProgress();
        }

        private void btnlvl4_Click(object sender, RoutedEventArgs e)
        {
            clicksound();

        }

        private void btnlvl5_Click(object sender, RoutedEventArgs e)
        {
            clicksound();

        }

        private void btnlvl6_Click(object sender, RoutedEventArgs e)
        {
            
           
        }

        private void btnlvl7_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnlvl8_Click(object sender, RoutedEventArgs e)
        {
           
         
        }

        private void btnlvl9_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnlvl10_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnlvl11_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnlvl12_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void btnlvl13_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnlvl14_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl15_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl16_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl17_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl18_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl19_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl20_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl21_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl22_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl23_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlvl24_Click(object sender, RoutedEventArgs e)
        {

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
            Menu_Window mnwid = new Menu_Window();
            mnwid.Show();
            this.Close();
        }

        private void Btnmusicoff_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            backgroundMusic.Stop();
        }

        private void Btnmusicon_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            backgroundMusic.Play();
        }
        private void clicksound()
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri("Resources/SoundEffect/mixkit-mouse-click-close-1113.wav", UriKind.Relative));
            player.Play();
        }
    }
}
