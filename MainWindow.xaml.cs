///using System.Reflection;
///using System.Reflection.Emit;
using System.Numerics;
using System.Reflection.Emit;
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
using static Tic_Tac_Toe_WPF.clsTicTacToe;

namespace Tic_Tac_Toe_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// create object reference
        /// </summary>
        public clsTicTacToe TicTacToe;

        /// <summary>
        /// boolean variable to keep track if the game has started
        /// </summary>
        public bool bHasStartedGame;

        ///bool to keep track of turns
        public bool player1Turn = true;

        /// <summary>
        /// initializes component and the clsTicTacToe object
        /// </summary>
        public MainWindow()
        {
            ///initialize component
            InitializeComponent();
            ///instantiate the object for the tictactoe class
            TicTacToe = new clsTicTacToe();
        }

        /// <summary>
        /// starts game when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ///reset the game
            Reset();
            ///turns on boolean variable to start game
            bHasStartedGame = true;
        }

        /// <summary>
        /// validates if game has started and if the square clicked is a valid move and carrys out move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerMoveClick(object sender, MouseButtonEventArgs e)
        {
            // Cast sender to Label
            System.Windows.Controls.Label labelC = sender as System.Windows.Controls.Label;
           

            if (bHasStartedGame == true)
            {

                //check if the square is empty to allow a move
                ///labelC.Content != "X" && labelC.Content != "O"
               
                if (string.IsNullOrEmpty(labelC.Content.ToString()))
                {
                    ///check if its player 1's turn
                    if (player1Turn == true)
                    {
                        ///load saboard with X using the name of the label 
                        TicTacToe.Board[(int)Char.GetNumericValue(labelC.Name[1]), (int)Char.GetNumericValue(labelC.Name[2])] = "X"; 
                        ///update content and turn
                        labelC.Content = "X";
                        player1Turn = false;
                        /// update label for who's turn it is
                        turnLbl.Content = "Player 2's Turn";
                    }
                    ///apply player2's turn if player 1 didnt go
                    else
                    {
                        ///load saboard with O using the name of the label 
                        TicTacToe.Board[(int)Char.GetNumericValue(labelC.Name[1]), (int)Char.GetNumericValue(labelC.Name[2])] = "O";
                       
                        ///update content and turn
                        labelC.Content = "O";
                        player1Turn = true;
                        /// update label for who's turn it is
                        turnLbl.Content = "Player 1's Turn";

                    }
                }

                //IsWinningMove
                if (TicTacToe.IsWinningMove() == true)
                {
                    Disable();

                    //HighlightWinningMove
                    HighlightWinningMove();

                    //UpdateStats, player1turn bool is opposite because it is already updated
                    if (player1Turn == false)
                    {
                        ///update stat
                        TicTacToe.Player1Wins++;
                        ///update label
                        nump1Wins.Content = TicTacToe.Player1Wins.ToString();
                        ///turn on winning label
                        p1WinLbl.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ///update stat
                        TicTacToe.Player2Wins++;
                        ///update label
                        nump2Wins.Content = TicTacToe.Player2Wins.ToString();
                        ///turn on winning label
                        p2WinLbl.Visibility = Visibility.Visible;
                    }


                    return;
                }
                //IsTie
                IsTie();
            }
        }

        ///checks for a tie
        private bool IsTie()
        {
            ///loop through rows
            for(int i = 0; i < 3; i++)
            {
                ///look through columns
                for (int j=0; j<3; j++)
                {
                    ///if any board square is empty return false, no tie
                        if (string.IsNullOrEmpty(TicTacToe.Board[i, j]))
                        {
                        return false;
                    }
                }
            }
            ///update stat
            TicTacToe.Ties++;
            ///update label
            numTies.Content = TicTacToe.Ties.ToString();


            ///if no empty squares return true because there is a tie
            return true;
        }

        /// <summary>
        /// This method will highlight the winning move based on the winner variable with the enum in clsTicTacToe
        /// </summary>
        private void HighlightWinningMove()
        {
            ///if row0 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Row0)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s00);
                ///setcolor of space 2
                SetBackgroundColor(s01);
                ///setcolor of space 3
                SetBackgroundColor(s02);
            }

            ///if row1 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Row1)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s10);
                ///setcolor of space 2
                SetBackgroundColor(s11);
                ///setcolor of space 3
                SetBackgroundColor(s12);
            }

            ///if row2 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Row2)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s20);
                ///setcolor of space 2
                SetBackgroundColor(s21);
                ///setcolor of space 3
                SetBackgroundColor(s22);
            }

            ///if col0 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Col0)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s00);
                ///setcolor of space 2
                SetBackgroundColor(s10);
                ///setcolor of space 3
                SetBackgroundColor(s20);
            }

            ///if col1 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Col1)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s01);
                ///setcolor of space 2
                SetBackgroundColor(s11);
                ///setcolor of space 3
                SetBackgroundColor(s21);
            }

            ///if col2 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Col2)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s02);
                ///setcolor of space 2
                SetBackgroundColor(s12);
                ///setcolor of space 3
                SetBackgroundColor(s22);
            }

            ///if diag0 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Diag0)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s00);
                ///setcolor of space 2
                SetBackgroundColor(s11);
                ///setcolor of space 3
                SetBackgroundColor(s22);
            }

            ///if diag1 is the winner it will be highlight by calling the proper method
            if (TicTacToe.Winner == WinningMove.Diag1)
            {
                ///setcolor of space 1 
                SetBackgroundColor(s02);
                ///setcolor of space 2
                SetBackgroundColor(s11);
                ///setcolor of space 3
                SetBackgroundColor(s20);
            }

        }

        /// <summary>
        /// sets background color
        /// </summary>
        /// <param name="lblLabel"></param>
        private void SetBackgroundColor(System.Windows.Controls.Label lblLabel)
        {
            ///set background color
            lblLabel.Background = new SolidColorBrush(System.Windows.Media.Colors.Yellow);
        }

        /// <summary>
        /// disables the buttons after winning
        /// </summary>
        private void Disable()
        {
            ///Disable Spaces
            ///disable panel 00
            s00.IsEnabled = false;
            ///disable panel 01
            s01.IsEnabled = false;
            ///disablepanel 02
            s02.IsEnabled = false;
            ///disable panel 10
            s10.IsEnabled = false;
            ///disablepanel 11
            s11.IsEnabled = false;
            ///disable panel 12
            s12.IsEnabled = false;
            ///disable panel 20
            s20.IsEnabled = false;
            ///disable panel 21
            s21.IsEnabled = false;
            ///disable panel 22
            s22.IsEnabled = false;
        }

        /// <summary>
        /// resets labels, gameboard, and variables except counters
        /// </summary>
        private void Reset()
        {
            /// reset who's turn it is
            player1Turn = true;

            /// reset label for who's turn it is
            turnLbl.Content = "Player 1's Turn";

            ///reenable Spaces
            ///reenable panel 00
            s00.IsEnabled = true;
            ///reenable panel 01
            s01.IsEnabled = true;
            ///reenable panel 02
            s02.IsEnabled = true;
            ///reenable panel 10
            s10.IsEnabled = true;
            ///reenable panel 11
            s11.IsEnabled = true;
            ///reenable panel 12
            s12.IsEnabled = true;
            ///reenable panel 20
            s20.IsEnabled = true;
            ///reenable panel 21
            s21.IsEnabled = true;
            ///reenable panel 22
            s22.IsEnabled = true;

            //Reset colors
            ///reset background color for panel 00
            s00.Background = Brushes.White;
            ///reset background color for panel 01
            s01.Background = Brushes.White;
            ///reset background color for panel 02
            s02.Background = Brushes.White;
            ///reset background color for panel 10
            s10.Background = Brushes.White;
            ///reset background color for panel 11
            s11.Background = Brushes.White;
            ///reset background color for panel 12
            s12.Background = Brushes.White;
            ///reset background color for panel 20
            s20.Background = Brushes.White;
            ///reset background color for panel 21
            s21.Background = Brushes.White;
            ///reset background color for panel 22
            s22.Background = Brushes.White;

            ///Reset Symbols
            ///reset symbol to blank for panel 00
            s00.Content = "";
            ///reset symbol to blank for panel 01
            s01.Content = "";
            ///reset symbol to blank for panel 02
            s02.Content = "";
            ///reset symbol to blank for panel 10
            s10.Content = "";
            ///reset symbol to blank for panel 11
            s11.Content = "";
            ///reset symbol to blank for panel 12
            s12.Content = "";
            ///reset symbol to blank for panel 20
            s20.Content = "";
            ///reset symbol to blank for panel 21
            s21.Content = "";
            ///reset symbol to blank for panel 22
            s22.Content = "";

            ///Reset Labels
            ///reset turn label
            turnLbl.Content = "Player 1's Turn";
            /// reset piwin1Lbl visibility to hidden 
            p1WinLbl.Visibility = Visibility.Hidden;
            /// reset piwin2Lbl visibility to hidden
            p2WinLbl.Visibility = Visibility.Hidden;
            /// resets the bhasstartedgame boolean variable
            bHasStartedGame = false;

            /// <summary>
            /// resets global variable to create the board
            /// </summary>
            /// loop through row
            for (int i = 0; i < 3; i++)
            {
                ///loop through column
                for (int j = 0; j < 3; j++)
                {
                    ///reset board
                    TicTacToe.Board[i, j] = "";

                }
            }

      
        /// <summary>
        /// resets which kind of winning move has been made
        /// </summary>
        TicTacToe.Winner = WinningMove.None;
        }

    }
}

    
