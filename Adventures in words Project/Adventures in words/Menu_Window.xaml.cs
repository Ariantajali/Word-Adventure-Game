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
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Media;

namespace Adventures_in_words
{
    /// <summary>
    /// Interaction logic for Menu_Window.xaml
    /// </summary>
    public partial class Menu_Window : Window
    {
        public Menu_Window()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            backgroundMusic.Play();
        }

        private void btnsetting_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            if (border4.Visibility == Visibility.Collapsed)
                {
                    
                    border4.Visibility = Visibility.Visible;
                    DoubleAnimation fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));
                    border4.BeginAnimation(OpacityProperty, fadeInAnimation);
                }
                else
                {
                    
                    DoubleAnimation fadeOutAnimation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.3));
                    fadeOutAnimation.Completed += (s, _) => border4.Visibility = Visibility.Collapsed;
                    border4.BeginAnimation(OpacityProperty, fadeOutAnimation);
                }
         }

        private void btnmusicon_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            backgroundMusic.Play();
        }

        private void btnmusicoff_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            backgroundMusic.Stop();
        }

        private void btninfo_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            InfoWindow intwin = new InfoWindow();
            intwin.Show();
        }

        private void btnorg_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level_Select levelSelect = new Level_Select();
            levelSelect.Show();
            Close();
        }

        private void btnchild_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            Level_Select_Game2 lvlsel2 = new Level_Select_Game2();
            lvlsel2.Show();
            Close();

        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            clicksound();
            this.Close();
        }
        private void clicksound()
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri("Resources/SoundEffect/mixkit-mouse-click-close-1113.wav", UriKind.Relative));
            player.Play();
        }
    }
}

