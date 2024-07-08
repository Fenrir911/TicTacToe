using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Square
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Player player;
        public bool SquarePlayed()
        {
            if (player == Player._)
                return false;
            return true;
        }
        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public void SquareChosen(Player play)
        {
            if(play == Player.X)
            {
                player = Player.X;
            }
            else if(play == Player.O)
            {
                player = Player.O;
            }
        }


        public enum Player { _ ,X, O  };
    }
}
