using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tic_Tac_Toe_WPF
{
    public class clsTicTacToe
    {
        /// <summary>
        /// global variable to create the board
        /// </summary>
        private string[,] saBoard;
        /// <summary>
        /// counter for player1 wins
        /// </summary>
        private int iPlayer1Wins;
        /// <summary>
        /// counter for player 2 wins
        /// </summary>
        private int iPlayer2Wins;
        /// <summary>
        /// counter for ties
        /// </summary>
        private int iTies;
        /// <summary>
        /// records which kind of winning move has been made
        /// </summary>
        private WinningMove eWinningMove;

        /// <summary>
        /// records the kinds of winning moves
        /// </summary>
        public enum WinningMove
        {
            /// <summary>
            /// no winning move
            /// </summary>
            None,
            /// <summary>
            /// row0 winnning move
            /// </summary>
            Row0,
            /// <summary>
            /// row1 winnning move
            /// </summary>
            Row1,
            /// <summary>
            /// row2 winnning move
            /// </summary>
            Row2,
            /// <summary>
            /// column0 winnning move
            /// </summary>
            Col0,
            /// <summary>
            /// column1 winnning move
            /// </summary>
            Col1,
            /// <summary>
            /// column2 winning move
            /// </summary>
            Col2,
            /// <summary>
            /// diagonal1 winning move
            /// </summary>
            Diag0,
            /// <summary>
            /// diagonal2 winning move
            /// </summary>
            Diag1,
        }

        //general constructor
        public clsTicTacToe()
        {
            ///initializes the sBoard to a blank board
            saBoard = new string[3, 3]
                {
                    { "", "", "" },
                    { "", "", "" },
                    { "", "", "" }
                };

            ///initializes the player 1 wins to 0
            iPlayer1Wins = 0;
            ///initializes the player 2 wins to 0
            iPlayer2Wins = 0;
            ///initializes the ties to 0
            iTies = 0;
            ///initializes the winningmove to none
            eWinningMove = WinningMove.None;
        }

        //properties for Board
        public string[,] Board
        {
            ///used to retrieve saBoard
            get
            {
                return saBoard;
            }

            ///used to redefine the saBoard
            set
            {
                saBoard = value;
            }
        }

        /// <summary>
        /// properties for iplayer1Wins
        /// </summary>
        public int Player1Wins
        {
            ///returns the iplayer1wins variable
            get
            {
                return iPlayer1Wins;
            }

            ///redefines the iplayer1wins variable
            set
            {
                iPlayer1Wins = value;
            }
        }

        /// <summary>
        /// properties for iplayer2Wins
        /// </summary>
        public int Player2Wins
        {
            ///returns the iplayer2wins variable
            get
            {
                return iPlayer2Wins;
            }

            ///redefines the iplayer2wins variable
            set
            {
                iPlayer2Wins = value;
            }
        }

        ///properties for iTies
        public int Ties
        {
            ///return the iTies variable
            get
            {
                return iTies;
            }
            /// updates the ities variable
            set
            {
                iTies = value;
            }
        }

        
        ///properties for winningmoves
        public WinningMove Winner
        {
            ///returns the winning move
            get
            {
                return eWinningMove;
            }
            ///redefines the winningmove
            set
            {
                eWinningMove = value;
            }
        }
        

        ///public clsTicTacToe.WinningMove TWinningMove { get; set; }

        /// <summary>
        /// Check if a winning move has been made
        /// </summary>
        /// <returns></returns>
        public bool IsWinningMove()
        {
            ///bool for hor win
            bool HorWin = IsHorWin();

            ///bool for vert win
            bool VertWin = IsVertWin();

            ///bool for diag win
            bool DiagWin = IsDiagWin();

            ///if any of the tests passed
            if (HorWin == true || VertWin == true || DiagWin == true)
            {
                return true;
            }
            ///if none of the winning moves have been made return false
            else
            {
                return false;
            }

        }

        /// <summary>
        ///check if a horizontal win has been made
        /// </summary>
        /// <returns></returns>
        private bool IsHorWin()
        {
            ///check if row0 isn't blank and matches
            if (saBoard[0, 0] != "" && saBoard[0, 0] == saBoard[0, 1] && saBoard[0, 1] == saBoard[0, 2])
            {
                ///assign winning row
                eWinningMove = WinningMove.Row0;
                return true;
            }
            ///check if row1 isn't blank and matches

            if (saBoard[1, 0] != "" && saBoard[1, 0] == saBoard[1, 1] && saBoard[1, 1] == saBoard[1, 2])
            {
                ///assign winning row

                eWinningMove = WinningMove.Row1;
                return true;
            }
            ///check if row2 isn't blank and matches

            if (saBoard[2, 0] != "" && saBoard[2, 0] == saBoard[2, 1] && saBoard[2, 1] == saBoard[2, 2])
            {
                ///assign winning row

                eWinningMove = WinningMove.Row2;
                return true;
            }
            ///no match return false
            else
            {
                return false;
            }
        }

        ///check if a vertical win has been made
        private bool IsVertWin()
        {
            ///check if col0 has match and not blank 
            if (saBoard[0, 0] != "" && saBoard[0, 0] == saBoard[1, 0] && saBoard[1, 0] == saBoard[2, 0])
            {
                ///assign winning row

                eWinningMove = WinningMove.Col0;
                return true;
            }
            ///check if col1 has match and not blank 

            if (saBoard[0, 1] != "" && saBoard[0, 1] == saBoard[1, 1] && saBoard[1, 1] == saBoard[2, 1])
            {
                ///assign winning row
                eWinningMove = WinningMove.Col1;
                return true;
            }
            ///check if col2 has match and not blank 

            if (saBoard[0, 2] != "" && saBoard[0, 2] == saBoard[1, 2] && saBoard[1, 2] == saBoard[2, 2])
            {
                ///assign winning row
                eWinningMove = WinningMove.Col2;
                return true;
            }
            else
            {
                return false;
            }

        }

        ///check if a diagonal win has been made
        private bool IsDiagWin()
        {
            ///check if diag0 has match and not blank 

            if (saBoard[0, 0] != "" && saBoard[0, 0] == saBoard[1, 1] && saBoard[1, 1] == saBoard[2, 2])
            {
                ///assign winning row
                eWinningMove = WinningMove.Diag0;
                return true;
            }
            ///check if diag1 has match and not blank 

            if (saBoard[0, 2] != "" && saBoard[0, 2] == saBoard[1, 1] && saBoard[1, 1] == saBoard[2, 0])
            {
                ///assign winning row
                eWinningMove = WinningMove.Diag1;
                return true;
            }
            else
            {
                return false;
            }
        }

        

    }
}
