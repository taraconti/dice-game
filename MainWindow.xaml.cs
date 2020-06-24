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

namespace DiceGame
{
    /* DICE CLASS
        * Stores which button the dice is associated with
        * Stores the color of the dice
        * Stores if the dice has been permanently selected
        * Stores the dice's current value
    */
    public class Dice
    {
        // Constructor to set the default of each variable
        public Dice(Button button, char letter)
        {
            button_ = button;
            letter_ = letter;
            button_.Content = "";
            button_.IsEnabled = false;
            color_ = 'b';
            selected_ = false;
            value_ = 0;
        }

        // Member variables
        public Button button_;
        public char color_;
        public bool selected_;
        public int value_;
        public char letter_;
    }

    /* PLAYER CLASS
        * Stores player's name
        * Stores player's score
    */
    public class Player
    {
        public Player(string name)
        {
            name_ = name;
            score_ = 0;
        }

        // Member variables
        public string name_;
        public int score_;
    }

    /* SCORE CLASS
        * Stores the name label
        * Stores the score label
    */
    public class Score
    {
        public Score(Label name, Label score)
        {
            nameLabel_ = name;
            scoreLabel_ = score;
        }

        // Member variables
        public Label nameLabel_;
        public Label scoreLabel_;
    }

    /* SCOREBOARD CLASS
        * Stores the current scoreboard display
        * Updates the scoreboard display
    */
    public class ScoreBoard

    { 
        public ScoreBoard(Score[] scores)
        {
            scoreBoard = scores;

            // Disable all scores initially
            for (int i = 0; i < 10; i++)
            {
                scoreBoard[i].nameLabel_.IsEnabled = false;
                scoreBoard[i].scoreLabel_.IsEnabled = false;
            }
        }

        public void updateBoard(List<Player> players)
        {
            // Sort the players by score (high to low)
            sortedPlayers = players;
            sortedPlayers.Sort((x, y) => y.score_.CompareTo(x.score_));

            // Update the names on the board
            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                scoreBoard[i].nameLabel_.IsEnabled = true;
                scoreBoard[i].nameLabel_.Content = sortedPlayers[i].name_.ToString();
                scoreBoard[i].scoreLabel_.IsEnabled = true;
                scoreBoard[i].scoreLabel_.Content = sortedPlayers[i].score_.ToString();
            }
        }

        public void findWinner(List<Player> players, Label winnerMessage, Border winnerBoard, Button playAgain, Button Quit)
        {
            // Update the board
            updateBoard(players);

            // Display winner message
            winnerBoard.Visibility = System.Windows.Visibility.Visible;
            winnerMessage.Content = sortedPlayers[0].name_ + " is the winner!";

            // Enable buttons
            playAgain.Visibility = System.Windows.Visibility.Visible;
            Quit.Visibility = System.Windows.Visibility.Visible;
        }

        // Member variables
        Score[] scoreBoard = new Score[10];
        List<Player> sortedPlayers = new List<Player>();
    }

    /* SCOREKEEPING CLASS
        * Helper function to calculate the score
        * Helper function to check if a board is scorable
        * Variables to hold scores for each round and roll
    */

    public class ScoreKeeping
    {
        public ScoreKeeping()
        {
            score = 0;
            tempScore = 0;
        }

        public void updateScore(Dice[] dice)
        {
            score += getScore(dice);
        }

        public int getScore(Dice[] dice)
        {
            // Holds the occurances of each possible value
            int[] count = new int[6];

            // Iterate through the dice
            for (int j = 0; j < 6; j++)
            {
                // If the current die has been chosen this round, record its value
                if ((dice[j].color_ == 'r') && !dice[j].selected_)
                {
                    count[dice[j].value_ - 1]++;
                }
            }

            // Check for special case 1 (1-2-3-4-5-6)
            int counter = 0;
            for (int i = 0; i < 6; i++)
            {
                if (count[i] == 1)
                {
                    counter++;
                }
            }
            // If all 6 values occur exactly once, there is a 1-2-3-4-5-6 straight
            if (counter == 6)
            {
                return 1000;
            }

            // Check for special case 2 (3 pairs)
            counter = 0;
            for (int i = 0; i < 6; i++)
            {
                if (count[i] == 2)
                {
                    counter++;
                }
            }
            // If there are three counts of exactly 2, there are 3 pairs
            if (counter == 3)
            {
                return 1000;
            }

            // Hold the total score as it gets computed
            int total = 0;

            // Iterate through the count of the values
            for (int i = 0; i < 6; i++)
            {
                // If there are less than three instances of a value
                if (count[i] > 0 && count[i] < 3)
                {
                    // If the value is a 1
                    if (i == 0)
                    {
                        total += (count[i] * 100);
                    }
                    // If the value is a 5
                    else if (i == 4)
                    {
                        total += (count[i] * 50);
                    }
                }
                else if (count[i] == 3)
                {
                    // If the value is 1
                    if (i == 0)
                    {
                        total += 1000;
                    }
                    else
                    {
                        total += ((i + 1) * 100);
                    }
                }
                else if (count[i] == 4)
                {
                    // If the value is 1
                    if (i == 0)
                    {
                        total += 2000;
                    }
                    else
                    {
                        total += ((i + 1) * 200);
                    }
                }
                else if (count[i] == 5)
                {
                    // If the value is 1
                    if (i == 0)
                    {
                        total += 4000;
                    }
                    else
                    {
                        total += ((i + 1) * 400);
                    }
                }
                else if (count[i] == 6)
                {
                    // If the value is 1
                    if (i == 0)
                    {
                        total += 8000;
                    }
                    else
                    {
                        total += ((i + 1) * 800);
                    }
                }
            }

            return total;
        }

        public bool checkScore(Dice[] dice)
        {
            // Holds the occurances of each possible value
            int[] count = { 0, 0, 0, 0, 0, 0 };

            // Iterate through the dice
            for (int j = 0; j < 6; j++)
            {
                // Count the unselected, black dice
                if (dice[j].color_ == 'b' && !dice[j].selected_)
                {
                    count[dice[j].value_ - 1]++;
                }
            }

            // Check for special case 1 (1-2-3-4-5-6)
            int counter = 0;
            for (int i = 0; i < 6; i++)
            {
                if (count[i] == 1)
                {
                    counter++;
                }
            }
            // If all 6 values occur exactly once, there is a 1-2-3-4-5-6 straight
            if (counter == 6)
            {
                return true;
            }

            // Check for special case 2 (3 pairs)
            counter = 0;
            for (int i = 0; i < 6; i++)
            {
                if (count[i] == 2)
                {
                    counter++;
                }
            }
            // If there are three counts of exactly 2, there are 3 pairs
            if (counter == 3)
            {
                return true;
            }

            // Iterate through the count of the values
            for (int i = 0; i < 6; i++)
            {
                // If there are less than three instances of a value
                if (count[i] > 0 && count[i] < 3)
                {
                    // If the value is a 1 or 5
                    if (i == 0 || i == 4)
                    {
                        return true;
                    }
                }
                else if (count[i] >= 3)
                {
                    return true;
                }
            }

            return false;
        }

        // Member variables
        public int score;
        public int tempScore;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Data members
        Dice[] dice = new Dice[6];
        List<Player> playerList = new List<Player>();
        int player = 0;
        ScoreBoard scoreDisplay;
        ScoreKeeping scoreHelper = new ScoreKeeping();
        Random rnd = new Random();
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            // Create each die
            dice[0] = new Dice(diceButton1, 'a');
            dice[1] = new Dice(diceButton2, 'b');
            dice[2] = new Dice(diceButton3, 'c');
            dice[3] = new Dice(diceButton4, 'd');
            dice[4] = new Dice(diceButton5, 'e');
            dice[5] = new Dice(diceButton6, 'f');

            // Create the score board
            Score[] scores = new Score[10];
            scores[0] = new Score(first_name, first_score);
            scores[1] = new Score(second_name, second_score);
            scores[2] = new Score(third_name, third_score);
            scores[3] = new Score(fourth_name, fourth_score);
            scores[4] = new Score(fifth_name, fifth_score);
            scores[5] = new Score(sixth_name, sixth_score);
            scores[6] = new Score(seventh_name, seventh_score);
            scores[7] = new Score(eigth_name, eigth_score);
            scores[8] = new Score(ninth_name, ninth_score);
            scores[9] = new Score(tenth_name, tenth_score);
            scoreDisplay = new ScoreBoard(scores);

            // Turn off the saveRoll button
            saveRoll.IsEnabled = false;

            // Turn on the roll button
            roll.IsEnabled = true;
        }

        // Loads Game Settings page
        private void Window_Loaded(object sender, EventArgs e)
        {
            string[] players = new string[10];
            GameSettings GSettings = new GameSettings(players);
            GSettings.Owner = this;
            GSettings.ShowDialog();

            // Create all the players
            for (int i = 0; i < 10; i++)
            {
                if (players[i] != null)
                {
                    playerList.Add(new Player(players[i]));
                }
            }

            // Update the scoreboard
            scoreDisplay.updateBoard(playerList);

            // Set player label
            playerLabel.Content = " " + playerList[player].name_.ToUpper() + "'S TURN";
        }

        private void dice1_Click(object sender, RoutedEventArgs e)
        {
            click(0);
        }

        private void dice2_Click(object sender, RoutedEventArgs e)
        {
            click(1);
        }
        private void dice3_Click(object sender, RoutedEventArgs e)
        {
            click(2);
        }
        private void dice4_Click(object sender, RoutedEventArgs e)
        {
            click(3);
        }

        private void dice5_Click(object sender, RoutedEventArgs e)
        {
            click(4);
        }

        private void dice6_Click(object sender, RoutedEventArgs e)
        {
            click(5);
        }

        // Processes a dice roll
        private void roll_Click(object sender, RoutedEventArgs e)
        {
            // Turn off the roll dice button
            roll.IsEnabled = false;

            // Turn off save roll button
            saveRoll.IsEnabled = false;

            // Turn on the dice buttons
            for (int i = 0; i < 6; i++)
            {
                dice[i].button_.IsEnabled = true;
            }

            // Reset the temp score
            scoreHelper.tempScore = 0;

            // Update the new score
            scoreHelper.updateScore(dice);

            // If all dice have been selected, reset the board
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                if (dice[i].color_ == 'r')
                {
                    count++;
                }
            }
            if (count == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    // Set the dice to black
                    dice[i].button_.BorderBrush = Brushes.Black;
                    dice[i].color_ = 'b';

                    // Set the dice to unselected
                    dice[i].selected_ = false;
                }
            }

            // Update which dice were selected
            for (int i = 0; i < 6; i++)
            {
                if (dice[i].color_ == 'r')
                {
                    dice[i].selected_ = true;
                }
            }

            // Roll the dice
            rollDice();

            // Check for bust
           bust();
        }

        // Processes saving a roll
        private void saveRoll_Click(object sender, RoutedEventArgs e)
        {
            // Turn off the saveRoll button
            saveRoll.IsEnabled = false;

            // Update the new score
            scoreHelper.updateScore(dice);

            // Add the curr score to the player's total score
            playerList[player].score_ += scoreHelper.score;

            // Update the scoreboard
            scoreDisplay.updateBoard(playerList);

            // Go to the next player's turn
            nextTurn();
        }



        /* HELPER FUNCTIONS */

        // Processes a dice button click
        public void click(int diceClicked)
        {
            // Count the number of times each value occurs
            int[] valCount = valueCount();

            // Count the number of times each value has been chosen
            int[] selectCount = valueSelectedCount();

            // Check special case 1 (1-2-3-4-5-6)
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                if (valCount[i] == 1)
                {
                    count++;
                }
            }
            // If all 6 values occur exactly once, there is a 1-2-3-4-5-6 straight
            if (count == 6)
            {
                // If there's a straight, clicking one die should select/unselect them all
                if (dice[diceClicked].button_.BorderBrush == Brushes.Red && !dice[diceClicked].selected_)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dice[i].button_.BorderBrush = Brushes.Black;
                        dice[i].color_ = 'b';
                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dice[i].button_.BorderBrush = Brushes.Red;
                        dice[i].color_ = 'r';
                    }
                }
            }

            // Check for special case 2 (3 pairs)
            int count2 = 0;
            for (int i = 0; i < 6; i++)
            {
                if (valCount[i] == 2)
                {
                    count2++;
                }
            }
            // If there are three counts of exactly 2, there are 3 pairs
            if (count2 == 3)
            {
                // If there are three pairs, clicking one die should select/unselect them all
                if (dice[diceClicked].button_.BorderBrush == Brushes.Red && !dice[diceClicked].selected_)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dice[i].button_.BorderBrush = Brushes.Black;
                        dice[i].color_ = 'b';
                    }
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        dice[i].button_.BorderBrush = Brushes.Red;
                        dice[i].color_ = 'r';
                    }
                }
            }

            // Only continue if both special cases did not occur
            if (count != 6 && count2 != 3)
            {
                if (dice[diceClicked].button_.BorderBrush == Brushes.Red && !dice[diceClicked].selected_)
                {
                    // If there are exactly three of the value, removing one should remove all of them
                    if ((selectCount[dice[diceClicked].value_ - 1] == 3) && (dice[diceClicked].value_ != 1) && (dice[diceClicked].value_ != 5))
                    {
                        // Set each die with the same value to black
                        for (int i = 0; i < 6; i++)
                        {
                            if (dice[i].value_ == dice[diceClicked].value_)
                            {
                                dice[i].button_.BorderBrush = Brushes.Black;
                                dice[i].color_ = 'b';
                            }
                        }
                    }
                    else
                    {
                        dice[diceClicked].button_.BorderBrush = Brushes.Black;
                        dice[diceClicked].color_ = 'b';
                    }
                }
                else if (!dice[diceClicked].selected_)
                {
                    // If there is a 3, 4, 5, or 6 of a kind, selecting one selects them all
                    if (valCount[dice[diceClicked].value_ - 1] >= 3)
                    {
                        // Set each die with the same value to red
                        for (int i = 0; i < 6; i++)
                        {
                            if (dice[i].value_ == dice[diceClicked].value_)
                            {
                                dice[i].button_.BorderBrush = Brushes.Red;
                                dice[i].color_ = 'r';
                            }
                        }
                    }
                    // Only let them select a 1 or a 5
                    else if (dice[diceClicked].value_ == 1 || dice[diceClicked].value_ == 5)
                    {
                        dice[diceClicked].button_.BorderBrush = Brushes.Red;
                        dice[diceClicked].color_ = 'r';
                    }
                }
            }

            // Set the score on the screen
            scoreHelper.tempScore = scoreHelper.getScore(dice);
            ScoreNum.Content = "SCORE: " + (scoreHelper.score + scoreHelper.tempScore).ToString();

            // Check if anything has been selected this round
            bool selected = selectCheck();

            if (selected)
            {
                bool all = allSelected();

                // If all 6 dice are selected, they must roll again before saving the roll
                if (all)
                {
                    roll.IsEnabled = true;
                    saveRoll.IsEnabled = false;
                }
                else
                {
                    roll.IsEnabled = true;

                    // If the player's current score is 0, allow them to save once they get to 1000
                    if (playerList[player].score_ == 0)
                    {

                        if (Convert.ToInt32(scoreHelper.score + scoreHelper.tempScore) >= 1000)
                        {
                            saveRoll.IsEnabled = true;
                        }
                        else
                        {
                            saveRoll.IsEnabled = false;
                        }
                    }
                    else
                    {
                        saveRoll.IsEnabled = true;
                    }
                }
            }
            else
            {
                roll.IsEnabled = false;
            }
        }

        // Gives a dice a new value
        public void rollDice()
        {
            for (int i = 0; i < 6; i++)
            {
                int roll = rnd.Next(1, 7);

                if (!dice[i].selected_)
                {
                    dice[i].value_ = roll;
                    dice[i].button_.Content = FindResource("DiceImage" + roll.ToString() + dice[i].letter_);
                    
                }
            }
        }

        // Counts how many times each value occurs in a specific round
        int[] valueCount()
        {
            int[] count = new int[6];

            for (int i = 0; i < 6; i++)
            {
                if (!dice[i].selected_)
                {
                    count[dice[i].value_ - 1]++;
                }
            }

            return count;
        }

        // Counts how many times each value has been selected in a specific round
        int[] valueSelectedCount()
        {
            int[] count = new int[6];

            for (int i = 0; i < 6; i++)
            {
                if ((dice[i].color_ == 'r') && !dice[i].selected_)
                {
                    count[dice[i].value_ - 1]++;
                }
            }

            return count;
        }

        // Checks if any dice have been selected this round
        bool selectCheck()
        {
            for (int i = 0; i < 6; i++)
            {
                if ((dice[i].color_ == 'r') && !dice[i].selected_)
                {
                    return true;
                }
            }

            return false;
        }

        // Checks if all dice have been selected
        bool allSelected()
        {
            for (int i = 0; i < 6; i++)
            {
                if ((dice[i].color_ == 'b') && !dice[i].selected_)
                {
                    return false;
                }
            }

            return true;
        }

        // Checks if unselected dice have a maximum score of 0
        void bust()
        {
            bool scored = scoreHelper.checkScore(dice);

            if (allSelected())
            {
                scored = true;
            }

            if (!scored)
            {
                // Turn off the dice buttons
                for (int i = 0; i < 6; i++)
                {
                    dice[i].button_.IsEnabled = false;
                }

                // Output "BUST" message
                bustMessage.Visibility = System.Windows.Visibility.Visible;

                // Set a timer to delay before going to the next player's turn
                timer.Tick += new EventHandler(timerComputerPlayer_Tick);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 2000);
                timer.Start();
            }
        }
        private void timerComputerPlayer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            // remove message
            bustMessage.Visibility = System.Windows.Visibility.Hidden;

            // go to the next turn
            nextTurn();
        }

        // Transitions the board to the next player's turn
        public void nextTurn()
        {
            // Set player to next turn it is
            if (player == playerList.Count - 1)
            {
                player = 0;
            }
            else
            {
                player++;
            }

            // If the upcoming player's score is over 10,000
            if (playerList[player].score_ >= 10000)
            {
                // Output winner message and end the game
                scoreDisplay.findWinner(playerList, winnerMessage, winnerBoard, playAgain, quit);
            }
            else
            { 
                // Reset the score to 0
                scoreHelper.score = 0;
                scoreHelper.tempScore = 0;
                ScoreNum.Content = "Score: " + scoreHelper.score.ToString();

                // Update player label
                playerLabel.Content = " " + playerList[player].name_.ToUpper() + "'S TURN";

                // Reset the dice
                for (int i = 0; i < 6; i++)
                {
                    // Set dice color to black
                    dice[i].button_.BorderBrush = Brushes.Black;
                    dice[i].color_ = 'b';

                    // Set dice to unselected
                    dice[i].selected_ = false;

                    // Clear their content
                    dice[i].button_.Content = "";

                    // Diable their buttons
                    dice[i].button_.IsEnabled = false;
                }

                // Turn on the roll button
                roll.IsEnabled = true;
            }
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            // Close the window
            this.Close();
        }

        private void playAgain_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
