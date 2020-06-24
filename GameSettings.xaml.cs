using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiceGame
{
    /// <summary>
    /// Interaction logic for GameSettings.xaml
    /// </summary>
    public partial class GameSettings : Window
    {
        // member variables
        string[] playerList = { "", "", "", "", "", "", "", "", "", ""};
        public GameSettings(string[] playerNames)
        {
            InitializeComponent();

            playerList = playerNames;
        }


        private void numPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selection = (ComboBoxItem)numPlayers.SelectedItem;

            if (selection.Content.ToString() == "1")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.LightGray;
                player2.Foreground = Brushes.LightGray;
                name2.IsEnabled = false;
                name3.Background = Brushes.LightGray;
                player3.Foreground = Brushes.LightGray;
                name3.IsEnabled = false;
                name4.Background = Brushes.LightGray;
                player4.Foreground = Brushes.LightGray;
                name4.IsEnabled = false;
                name5.Background = Brushes.LightGray;
                player5.Foreground = Brushes.LightGray;
                name5.IsEnabled = false;
                name6.Background = Brushes.LightGray;
                player6.Foreground = Brushes.LightGray;
                name6.IsEnabled = false;
                name7.Background = Brushes.LightGray;
                player7.Foreground = Brushes.LightGray;
                name7.IsEnabled = false;
                name8.Background = Brushes.LightGray;
                player8.Foreground = Brushes.LightGray;
                name8.IsEnabled = false;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "2")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.LightGray;
                player3.Foreground = Brushes.LightGray;
                name3.IsEnabled = false;
                name4.Background = Brushes.LightGray;
                player4.Foreground = Brushes.LightGray;
                name4.IsEnabled = false;
                name5.Background = Brushes.LightGray;
                player5.Foreground = Brushes.LightGray;
                name5.IsEnabled = false;
                name6.Background = Brushes.LightGray;
                player6.Foreground = Brushes.LightGray;
                name6.IsEnabled = false;
                name7.Background = Brushes.LightGray;
                player7.Foreground = Brushes.LightGray;
                name7.IsEnabled = false;
                name8.Background = Brushes.LightGray;
                player8.Foreground = Brushes.LightGray;
                name8.IsEnabled = false;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "3")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.LightGray;
                player4.Foreground = Brushes.LightGray;
                name4.IsEnabled = false;
                name5.Background = Brushes.LightGray;
                player5.Foreground = Brushes.LightGray;
                name5.IsEnabled = false;
                name6.Background = Brushes.LightGray;
                player6.Foreground = Brushes.LightGray;
                name6.IsEnabled = false;
                name7.Background = Brushes.LightGray;
                player7.Foreground = Brushes.LightGray;
                name7.IsEnabled = false;
                name8.Background = Brushes.LightGray;
                player8.Foreground = Brushes.LightGray;
                name8.IsEnabled = false;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "4")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.White;
                player4.Foreground = Brushes.Black;
                name4.IsEnabled = true;
                name5.Background = Brushes.LightGray;
                player5.Foreground = Brushes.LightGray;
                name5.IsEnabled = false;
                name6.Background = Brushes.LightGray;
                player6.Foreground = Brushes.LightGray;
                name6.IsEnabled = false;
                name7.Background = Brushes.LightGray;
                player7.Foreground = Brushes.LightGray;
                name7.IsEnabled = false;
                name8.Background = Brushes.LightGray;
                player8.Foreground = Brushes.LightGray;
                name8.IsEnabled = false;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "5")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.White;
                player4.Foreground = Brushes.Black;
                name4.IsEnabled = true;
                name5.Background = Brushes.White;
                player5.Foreground = Brushes.Black;
                name5.IsEnabled = true;
                name6.Background = Brushes.LightGray;
                player6.Foreground = Brushes.LightGray;
                name6.IsEnabled = false;
                name7.Background = Brushes.LightGray;
                player7.Foreground = Brushes.LightGray;
                name7.IsEnabled = false;
                name8.Background = Brushes.LightGray;
                player8.Foreground = Brushes.LightGray;
                name8.IsEnabled = false;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "6")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.White;
                player4.Foreground = Brushes.Black;
                name4.IsEnabled = true;
                name5.Background = Brushes.White;
                player5.Foreground = Brushes.Black;
                name5.IsEnabled = true;
                name6.Background = Brushes.White;
                player6.Foreground = Brushes.Black;
                name6.IsEnabled = true;
                name7.Background = Brushes.LightGray;
                player7.Foreground = Brushes.LightGray;
                name7.IsEnabled = false;
                name8.Background = Brushes.LightGray;
                player8.Foreground = Brushes.LightGray;
                name8.IsEnabled = false;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "7")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.White;
                player4.Foreground = Brushes.Black;
                name4.IsEnabled = true;
                name5.Background = Brushes.White;
                player5.Foreground = Brushes.Black;
                name5.IsEnabled = true;
                name6.Background = Brushes.White;
                player6.Foreground = Brushes.Black;
                name6.IsEnabled = true;
                name7.Background = Brushes.White;
                player7.Foreground = Brushes.Black;
                name7.IsEnabled = true;
                name8.Background = Brushes.LightGray;
                player8.Foreground = Brushes.LightGray;
                name8.IsEnabled = false;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "8")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.White;
                player4.Foreground = Brushes.Black;
                name4.IsEnabled = true;
                name5.Background = Brushes.White;
                player5.Foreground = Brushes.Black;
                name5.IsEnabled = true;
                name6.Background = Brushes.White;
                player6.Foreground = Brushes.Black;
                name6.IsEnabled = true;
                name7.Background = Brushes.White;
                player7.Foreground = Brushes.Black;
                name7.IsEnabled = true;
                name8.Background = Brushes.White;
                player8.Foreground = Brushes.Black;
                name8.IsEnabled = true;
                name9.Background = Brushes.LightGray;
                player9.Foreground = Brushes.LightGray;
                name9.IsEnabled = false;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "9")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.White;
                player4.Foreground = Brushes.Black;
                name4.IsEnabled = true;
                name5.Background = Brushes.White;
                player5.Foreground = Brushes.Black;
                name5.IsEnabled = true;
                name6.Background = Brushes.White;
                player6.Foreground = Brushes.Black;
                name6.IsEnabled = true;
                name7.Background = Brushes.White;
                player7.Foreground = Brushes.Black;
                name7.IsEnabled = true;
                name8.Background = Brushes.White;
                player8.Foreground = Brushes.Black;
                name8.IsEnabled = true;
                name9.Background = Brushes.White;
                player9.Foreground = Brushes.Black;
                name9.IsEnabled = true;
                name10.Background = Brushes.LightGray;
                player10.Foreground = Brushes.LightGray;
                name10.IsEnabled = false;
            }
            else if (selection.Content.ToString() == "10")
            {
                name1.Background = Brushes.White;
                player1.Foreground = Brushes.Black;
                name1.IsEnabled = true;
                name2.Background = Brushes.White;
                player2.Foreground = Brushes.Black;
                name2.IsEnabled = true;
                name3.Background = Brushes.White;
                player3.Foreground = Brushes.Black;
                name3.IsEnabled = true;
                name4.Background = Brushes.White;
                player4.Foreground = Brushes.Black;
                name4.IsEnabled = true;
                name5.Background = Brushes.White;
                player5.Foreground = Brushes.Black;
                name5.IsEnabled = true;
                name6.Background = Brushes.White;
                player6.Foreground = Brushes.Black;
                name6.IsEnabled = true;
                name7.Background = Brushes.White;
                player7.Foreground = Brushes.Black;
                name7.IsEnabled = true;
                name8.Background = Brushes.White;
                player8.Foreground = Brushes.Black;
                name8.IsEnabled = true;
                name9.Background = Brushes.White;
                player9.Foreground = Brushes.Black;
                name9.IsEnabled = true;
                name10.Background = Brushes.White;
                player10.Foreground = Brushes.Black;
                name10.IsEnabled = true;
            }
        }

        private void name1_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[0] = name1.Text.ToString();
        }

        private void name2_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[1] = name2.Text.ToString();
        }

        private void name3_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[2] = name3.Text.ToString();
        }

        private void name4_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[3] = name4.Text.ToString();
        }

        private void name5_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[4] = name5.Text.ToString();
        }

        private void name6_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[5] = name6.Text.ToString();
        }

        private void name7_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[6] = name7.Text.ToString();
        }

        private void name8_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[7] = name8.Text.ToString();
        }

        private void name9_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[8] = name9.Text.ToString();
        }

        private void name10_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerList[9] = name10.Text.ToString();
        }

        private void computer1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void computer2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void computer3_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void computer4_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void computer5_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void computer6_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void computer7_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void computer8_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void computer9_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void computer10_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void start_Click_1(object sender, RoutedEventArgs e)
        {
            // close the window
            this.Close();
        }
    }
}
