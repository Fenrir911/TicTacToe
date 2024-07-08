using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class InputManager
    {
        public int Turn { get; set; }
        public int TurnLimit { get; } = 9;
        public bool GameDraw() => Turn > TurnLimit;
        private bool ShouldPlay;
        public Square.Player playerX { get; } = Square.Player.X;
        public Square.Player playerO { get; } = Square.Player.O;
        private static Square.Player _player = Square.Player._;
        public Square.Player winner = _player;

        public Board board = new Board();
        public InputManager()
        {
            Turn = 1;
        }
        public void InitializeGame()
        {
            do
            {
                Turn = 1;
                while (!GameDraw())
                {
                    GameTurn();
                    if (PlayerWon() != _player)
                        break;
                }
                Console.Write("Would you like to play again? Y/N  ");
                string readResult = Console.ReadLine().ToLower();
                if (readResult != null)
                {
                    ShouldPlay = readResult == "y" ? true : false;
                }


            } while (ShouldPlay == true);



               Console.ReadKey();
        }

        private void GameTurn()
        {
            board.UpdateBoard();
            AskPlayerInput();
        }
        private Square.Player CurrentPlayer()
        {
            if (Turn % 2 != 0)
                return playerX;
            else if (Turn % 2 == 0)
                return playerO;
            return _player;
        }


        private Square.Player PlayerWon()
        {

            if (CheckCols() != _player)
            {
                Console.WriteLine($"Player {CheckCols()} has won");
                return CheckCols();
            }
            else if (CheckRows() != _player)
            {
                Console.WriteLine($"Player {CheckRows()} has won");
                return CheckRows();
            }
            else if (CheckDiagnols() != _player)
            {
                Console.WriteLine($"Player {CheckDiagnols()} has won");
                return CheckDiagnols();
            }

            return _player;
        }

        private Square.Player CheckDiagnols()
        {
            int counterX = 0;
            int counterO = 0;
            for (int i = 0; i < 3; i++)
            {
                if (board.StartBoard[i, i].player == playerX)
                {
                    counterX++;
                }
                else if (board.StartBoard[i, i].player == playerO)
                {
                    counterO++;
                }
                else if (board.StartBoard[0, 2].player == playerX && board.StartBoard[1, 1].player == playerX && board.StartBoard[2, 0].player == playerX)
                    return playerX;
                else if (board.StartBoard[0, 2].player == playerO && board.StartBoard[1, 1].player == playerO && board.StartBoard[2, 0].player == playerO)
                    return playerO;
            }
            if (counterX == 3)
                return playerX;
            else if (counterO == 3)
                return playerO;
            return _player;
        }
        private Square.Player CheckRows()
        {
            for (int i = 0; i < Board.RowMax; i++)
            { int counterX = 0;
                int counterO = 0;
                for (int j = 0; j < Board.ColMax; j++)
                {
                    if (board.StartBoard[i,j].player == playerX)
                    {
                        counterX++;
                    }
                    else if (board.StartBoard[i, j].player == playerO)
                    {
                        counterO++;
                    }
                }
                if (counterX == 3)
                return playerX;
                else if (counterO == 3) 
                return playerO;
            }
            return _player;
        }
        private Square.Player CheckCols()
        {
            for (int i = 0; i < Board.ColMax; i++)
            {
                int counterX = 0;
                int counterO = 0;
                for (int j = 0; j < Board.RowMax; j++)
                {
                    if (board.StartBoard[j, i].player == playerX)
                    {
                        counterX++;
                    }
                    else if (board.StartBoard[j, i].player == playerO)
                    {
                        counterO++;
                    }
                }
                if (counterX == 3)
                    return playerX;
                else if (counterO == 3)
                    return playerO;
            }
            return _player;
        }

        private void AskPlayerInput()
        {
            bool validEntry = false;
            bool legalMove = false;
            int input = 0;
            string readResult;
            do
            {
                Console.WriteLine($"\nPlayer {CurrentPlayer()}, play your move\nEnter the number to place symbol on:\n1, 2, 3\n4, 5, 6\n7, 8, 9\n");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    validEntry = int.TryParse(readResult, out input);
                    if (validEntry)
                    {
                        switch (input)
                        {
                            case 1:
                                if (board.StartBoard[0, 0].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[0, 0].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 2:
                                if (board.StartBoard[0, 1].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[0, 1].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 3:
                                if (board.StartBoard[0, 2].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[0, 2].SquareChosen(CurrentPlayer()); 
                                Turn++;
                                break;
                            case 4:
                                if (board.StartBoard[1, 0].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[1, 0].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 5:
                                if (board.StartBoard[1, 1].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[1, 1].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 6:
                                if (board.StartBoard[1, 2].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[1, 2].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 7:
                                if (board.StartBoard[2, 0].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[2, 0].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 8:
                                if (board.StartBoard[2, 1].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[2, 1].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 9:
                                if (board.StartBoard[2, 2].SquarePlayed())
                                {
                                    Console.WriteLine("Square has already been played.");
                                    continue;
                                }
                                legalMove = true;
                                board.StartBoard[2, 2].SquareChosen(CurrentPlayer());
                                Turn++;
                                break;
                            case 0:
                            default:
                                continue;
                        }
                    }
                }

            } while (validEntry == false && legalMove == false);

    }
    }
}
