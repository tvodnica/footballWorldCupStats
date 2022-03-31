using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string playerName = "";
            List<Data.Player> players = new List<Data.Player>();
            try
            {
                playerName = Data.Files.LoadSelectedPlayerFile();
                players = Data.Files.LoadPlayersFromCurrentMatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

            foreach (var player in players)
            {
                if (playerName == player.Name)
                {
                    if (player.Image!="")
                    {
                        image_playerImage.Source = new BitmapImage { UriSource = new Uri(player.Image) };
                    }
                    text_playerName.Text = player.Name;
                    text_playerNumber.Text = player.ShirtNumber.ToString();
                    text_playerPosition.Text = player.Position;
                    text_playerIsCaptain.Text = player.Captain?"DA":"NE";
                    text_playeGoals.Text = player.GoalsInThisMatch.ToString();
                    text_playerYellowCards.Text = player.YellowCards.ToString();

                    break;

                }
            }

        }
    }
}
