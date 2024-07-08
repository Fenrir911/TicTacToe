using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        public static int RowMax { get; } = 3;
        public static int ColMax { get; } = 3;

        public Square[,] StartBoard = new Square[RowMax, ColMax];

        // Create board with 3 rows and 3 columns of squares
       public Board()
        {
            for (int i = 0; i < RowMax; i++)
            {
                for(int j = 0; j < ColMax; j++)
                {
                    StartBoard[i, j] = new Square(i,j);
                }
            }
        }
        public void UpdateBoard()
        {
            for(int i = 0; i < RowMax; i++)
            {
                for (int j = 0; j < ColMax;  j++)
                {
                    if (j == ColMax - 1)
                    {
                        switch (StartBoard[i, j].player)
                        {
                            case Square.Player._:
                                Console.Write("   ");
                                break;
                            case Square.Player.X:
                                Console.Write(" X ");
                                break;
                            case Square.Player.O:
                                Console.Write(" O ");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (StartBoard[i, j].player)
                        {
                            case Square.Player._:
                                Console.Write("   |");
                                break;
                            case Square.Player.X:
                                Console.Write(" X |");
                                break;
                            case Square.Player.O:
                                Console.Write(" O |");
                                break;
                            default:
                                break;

                        }
                    }
                }
                if (i != RowMax - 1)
                { Console.WriteLine("\n---+---+---"); }
;            }

        }
        

    }
}
