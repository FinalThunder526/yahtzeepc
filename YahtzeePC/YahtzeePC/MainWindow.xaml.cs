using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YahtzeePC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Yahtzee y = new Yahtzee();
        
        public MainWindow()
        {
            InitializeComponent();
            turns.Text = y.rollsPerTurn + "";
            //SetHelpText();
        }

        // TODO: Disable the button immediately after the user clicks it for the third time.
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            setDice();
            y.Roll();
            changeValues();
            
        }

        private void changeValues()
        {
            dice0.Content = y.dice[0] + "";
            dice1.Content = y.dice[1] + "";
            dice2.Content = y.dice[2] + "";
            dice3.Content = y.dice[3] + "";
            dice4.Content = y.dice[4] + "";
            turns.Text = (3 - y.turnCount) + "";
            //label3.Content = y.totalTurns + "";
            totalScore.Text = y.totalScore + "";
        }
        private void setDice()
        {
            y.selected[0] = (Boolean)(dice0.IsChecked);
            y.selected[1] = (Boolean)(dice1.IsChecked);
            y.selected[2] = (Boolean)(dice2.IsChecked);
            y.selected[3] = (Boolean)(dice3.IsChecked);
            y.selected[4] = (Boolean)(dice4.IsChecked);
        }
        public void newTurn()
        {
            dice0.IsChecked = false;
            dice1.IsChecked = false;
            dice2.IsChecked = false;
            dice3.IsChecked = false;
            dice4.IsChecked = false;
            setDice();
            y.totalTurns++;
            if (y.totalTurns < 13)
                y.newTurn();
            else
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            button1.IsEnabled = false;
            MessageBoxResult result = MessageBox.Show("Game Over!\nWell played, your total score is " + y.totalScore +" points!\nClick OK to play again.\nClick Cancel to end the game.", "Game Over!", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            switch (result)
            {
                case(MessageBoxResult.OK):
                    NewGame();
                    break;
                case(MessageBoxResult.Cancel):
                    this.Close();
                    break;
            }
        }

        private void NewGame()
        {
            y.totalTurns = -1;
            newTurn(); 
            y.totalScore = 0;
            RefreshScorings();
            changeValues();
            button1.IsEnabled = true;
        }

        private void RefreshScorings()
        {
            checkBox1.IsEnabled = true; checkBox1.IsChecked = false;
            checkBox2.IsEnabled = true; checkBox2.IsChecked = false;
            checkBox3.IsEnabled = true; checkBox3.IsChecked = false;
            checkBox4.IsEnabled = true; checkBox4.IsChecked = false;
            checkBox5.IsEnabled = true; checkBox5.IsChecked = false;
            checkBox6.IsEnabled = true; checkBox6.IsChecked = false;
            checkBox7.IsEnabled = true; checkBox7.IsChecked = false;
            checkBox8.IsEnabled = true; checkBox8.IsChecked = false;
            checkBox9.IsEnabled = true; checkBox9.IsChecked = false;
            checkBox10.IsEnabled = true; checkBox10.IsChecked = false;
            checkBox11.IsEnabled = true; checkBox11.IsChecked = false;
            checkBox12.IsEnabled = true; checkBox12.IsChecked = false;
            checkBox13.IsEnabled = true; checkBox13.IsChecked = false;

            acesScore.Text = 0 + "";
            twosScore.Text = 0 + "";
            threesScore.Text = 0 + "";
            foursScore.Text = 0 + "";
            fivesScore.Text = 0 + "";
            sixesScore.Text = 0 + "";
            threeKindScore.Text = 0 + "";
            fourKindScore.Text = 0 + "";
            smStraightScore.Text = 0 + "";
            lStraightScore.Text = 0 + "";
            yScore.Text = 0 + "";
            chanceScore.Text = 0 + "";
        }
        
        // aces
        private void checkBox6_Checked(object sender, RoutedEventArgs e)
        {
            acesScore.Text = y.numbers(1) + "";
            checkBox6.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // twos
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            twosScore.Text = y.numbers(2) + "";
            checkBox1.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // threes
        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            threesScore.Text = y.numbers(3) + "";
            checkBox2.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // fours
        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            foursScore.Text = y.numbers(4) + "";
            checkBox3.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // fives
        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            fivesScore.Text = y.numbers(5) + "";
            checkBox4.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // sixesC
        private void checkBox5_Checked(object sender, RoutedEventArgs e)
        {
            sixesScore.Text = y.numbers(6) + "";
            checkBox5.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // three of a kind
        private void checkBox12_Checked(object sender, RoutedEventArgs e)
        {
            threeKindScore.Text = y.ofAKind(3) + "";
            checkBox12.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // four of a kind
        private void checkBox7_Checked(object sender, RoutedEventArgs e)
        {
            fourKindScore.Text = y.ofAKind(4) + "";
            checkBox7.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // chance
        private void checkBox13_Checked(object sender, RoutedEventArgs e)
        {
            chanceScore.Text = y.chance() + "";
            checkBox13.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // yahtzee
        private void checkBox11_Checked(object sender, RoutedEventArgs e)
        {
            yScore.Text = y.yahtzee() + "";
            checkBox11.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // small straight
        private void checkBox8_Checked(object sender, RoutedEventArgs e)
        {
            smStraightScore.Text = y.straight(4) + "";
            checkBox8.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // large straight
        private void checkBox9_Checked(object sender, RoutedEventArgs e)
        {
            lStraightScore.Text = y.straight(5) + "";
            checkBox9.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }
        // full house
        private void checkBox10_Checked(object sender, RoutedEventArgs e)
        {
            fhouseScore.Text = y.fullHouse() + "";
            checkBox10.IsEnabled = false;
            changeValues();
            newTurn();
            changeValues();
        }

        int n = 0;
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBoxResult.OK;
            while (result.Equals(MessageBoxResult.OK) && n <= 8)
            {
                SetHelpText(n);
                result = MessageBox.Show(text, caption, MessageBoxButton.OKCancel, MessageBoxImage.Information);
                n++;
            }
            n = 0;
        }
        string text, caption;

        private void SetHelpText(int n)
        {
            System.Text.Encoding Encoder = System.Text.ASCIIEncoding.Default;
            Byte[] buffer = new byte[] { (byte)149 };
            string bullet = Encoding.GetEncoding(1252).GetString(buffer);
            if (n == 0)
            {
                caption = "Introduction";
                text = "The game consists of 13 rounds. In each round, you roll the dice and then score the roll in one of 13 categories. You must score once in each category -- which means that towards the end of the game you may have to settle for scoring zero in some categories. The score is determined by a different rule for each category.";
            }
            else if (n == 1)
            {
                caption = "Rolling the Dice";
                text = bullet + " You have five dice which you can roll, represented by the five numbers at the top of the window. To start with, you roll all dice by clicking on the Roll button. After you roll all dice, you can either score the current roll, or re-roll any or all of the five dice.";
                text += "\n" + bullet + " To re-roll some of the dice, click on the check box next to the die you want to keep. Then, click on the Roll button. This will re-roll the unselected dice, leaving the selected ones unchanged.";
                text += "\n" + bullet + " You can roll the dice a total of three times - the initial roll (in which you must roll all the dice), plus two re-rolls of any or all dice. After rolling three times, you must score the roll.";
                text += "\n" + bullet + " Once you've scored the roll, you roll all the dice again and repeat the process. You continue until all 13 categories have been filled, at which time the game is over.";
            }
            else if (n == 2)
            {
                caption = "Scoring: Upper House";
                text = bullet + " In the upper scores, you total only the specified die face.";
                text += "\n" + bullet + " So, a roll of \n{3, 3, 3, 4, 5} \nwill give you 9 points in the 3's category, or 4 points in the 4's category, or 5 points in the 5's category.";
            }
            else if (n == 3)
            {
                caption = "Scoring: Lower House";
                text = bullet + " In the lower scores, you score either a set amount (defined by the category), or zero if you don't satisfy the category requirements.";
            }
            else if (n == 4)
            {
                caption = "Scoring: Lower House: Three+Four of a Kind";
                text = bullet + " For 3 of a Kind, you must have at least three of the same die faces. If so, you total all the die faces and score that total.";
                text += "\n" + bullet + " Similarly for 4 of a Kind, except that you must have 4 of the 5 die faces the same.";
                text += "\n" + bullet + " So for example, if you rolled \n{5, 5, 3, 2, 5} \nyou would receive 20 points for 3 of a Kind, but zero points for 4 of a Kind.";
            }
            else if (n == 5)
            {
                caption = "Scoring: Lower House: Straights";
                text = bullet + " Like in poker, a straight is a sequence of consecutive die faces; a small straight is 4 consecutive faces, and a large straight is 5 consecutive faces.";
                text += "\n" + bullet + " Small straights score 30 points and large straights score 40 points.";
                text += "\n" + bullet + " Thus, if you rolled: \n{5, 4, 3, 2, 6} \nyou could score either a small straight or a large straight, since this roll satisfies both.";
            }
            else if (n == 6)
            {
                caption = "Scoring: Lower House: Full House";
                text = bullet + " A Full House is a roll where you have a 3 of a kind as well as a pair. Full houses score 25 points.";
                text += "\n" + bullet + " Here is an example of a full house: \n{3, 3, 5, 3, 5}";
            }
            else if (n == 7)
            {
                caption = "Scoring: Lower House: Yahtzee";
                text = bullet + " A Yahtzee is a 5 of a Kind (i.e. all the die faces are the same), and it scores 50 points, regardless of what number appears 5 times.";
                text += "\n" + bullet + " Here is an example of a Yahtzee: \n{5, 5, 5, 5, 5}";
            }
            else if (n == 8)
            {
                caption = "Scoring: Lower House: Chance";
                text = bullet + " Chance is the catch-all roll. You can roll anything and you simply total all the die faces values.";
                text += "\n" + bullet + " Your score on a roll like \n{1, 3, 2, 6, 3} \nwould be 15.";
            }
        }
        
    }
}
