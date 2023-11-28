using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class TetrisGame
    {
        private TetrisForm form;
        Blocks block;
        private int[,] gameField;
        public TetrisGame(TetrisForm form)
        {
            block = new Blocks();
            block.newRandomBlock();
            gameField = new int[10, 22];
            this.form = form;
        }
        public void nextTick()
        {
            downByOne();
            updateGameField();

        }

        private void updateGameField()
        {
            form.ResetGameField();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 22; y++)
                {
                    form.PlaceBlock(x, y, gameField[x,y]);
                }
            }
            form.PlaceBlock(block.BlockMiddle.X, block.BlockMiddle.Y,2);
            form.PlaceBlock(block.BlockA.X, block.BlockA.Y, 2);
            form.PlaceBlock(block.BlockB.X, block.BlockB.Y, 2);
            form.PlaceBlock(block.BlockC.X, block.BlockC.Y, 2);
        }

        private void downByOne()
        {
            if (block.BlockMiddle.Y < 21 && block.BlockA.Y < 21 && block.BlockB.Y < 21 && block.BlockC.Y < 21)
            {
                if (gameField[block.BlockMiddle.X, block.BlockMiddle.Y + 1] < 2 && gameField[block.BlockA.X, block.BlockA.Y + 1] < 2
                    && gameField[block.BlockB.X, block.BlockB.Y + 1] < 2 && gameField[block.BlockC.X, block.BlockC.Y + 1] < 2)
                {
                    block.BlockMiddle.Y += 1;
                    block.BlockA.Y += 1;
                    block.BlockB.Y += 1;
                    block.BlockC.Y += 1;
                }
                else
                {
                    gameField[block.BlockMiddle.X, block.BlockMiddle.Y] = 2;
                    gameField[block.BlockA.X, block.BlockA.Y] = 2;
                    gameField[block.BlockB.X, block.BlockB.Y] = 2;
                    gameField[block.BlockC.X, block.BlockC.Y] = 2;
                    block.newRandomBlock();
                }
            }
            else
            {
                gameField[block.BlockMiddle.X, block.BlockMiddle.Y] = 2;
                gameField[block.BlockA.X, block.BlockA.Y] = 2;
                gameField[block.BlockB.X, block.BlockB.Y] = 2;
                gameField[block.BlockC.X, block.BlockC.Y] = 2;
                block.newRandomBlock();
            }
        }


    }
}
