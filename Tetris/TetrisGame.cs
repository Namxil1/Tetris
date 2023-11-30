﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
//Hallo
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
        }
        public void newBlock()
        {
            ClearRows();
            block.newRandomBlock();
        }
        private void ClearRows()
        {
            for (int y = 0; y < 22; y++)
            {
                bool isRowFull = true;

               //Check ob Reihe voll
                for (int x = 0; x < 10; x++)
                {
                    if (gameField[x, y] < 2)
                    {
                        isRowFull = false;
                        break;
                    }
                }

                //Alle Reihen runter
                if (isRowFull)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        gameField[x, y] = 0;
                    }

                    for (int i = y - 1; i >= 0; i--)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            gameField[x, i + 1] = gameField[x, i];
                        }
                    }
                }
            }
        }

        private void updateGameField()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 22; y++)
                {
                    form.PlaceBlock(x, y, gameField[x,y]);
                }
            }
            form.PlaceBlock(block.BlockMiddle.X, block.BlockMiddle.Y,1);
            form.PlaceBlock(block.BlockA.X, block.BlockA.Y, 1);
            form.PlaceBlock(block.BlockB.X, block.BlockB.Y, 1);
            form.PlaceBlock(block.BlockC.X, block.BlockC.Y, 1);
        }

        public void downByOne()
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
                    newBlock();
                }
            }
            else
            {
                gameField[block.BlockMiddle.X, block.BlockMiddle.Y] = 2;
                gameField[block.BlockA.X, block.BlockA.Y] = 2;
                gameField[block.BlockB.X, block.BlockB.Y] = 2;
                gameField[block.BlockC.X, block.BlockC.Y] = 2;
                newBlock();
            }
            updateGameField();
        }

        public void moveLeft()
        {
            if (block.BlockMiddle.X > 0 && block.BlockA.X > 0 && block.BlockB.X > 0 && block.BlockC.X > 0)
            {
                if (gameField[block.BlockMiddle.X-1, block.BlockMiddle.Y] < 2 && gameField[block.BlockA.X -1, block.BlockA.Y] < 2
                    && gameField[block.BlockB.X-1, block.BlockB.Y] < 2 && gameField[block.BlockC.X-1, block.BlockC.Y] < 2)
                {
                    block.BlockMiddle.X -= 1;
                    block.BlockA.X -= 1;
                    block.BlockB.X -= 1;
                    block.BlockC.X -= 1;

                    updateGameField();
                }
            }
        }

        internal void moveRight()
        {
            if (block.BlockMiddle.X < 9 && block.BlockA.X < 9 && block.BlockB.X < 9 && block.BlockC.X < 9)
            {
                if (gameField[block.BlockMiddle.X + 1, block.BlockMiddle.Y] < 2 && gameField[block.BlockA.X + 1, block.BlockA.Y] < 2
                    && gameField[block.BlockB.X + 1, block.BlockB.Y] < 2 && gameField[block.BlockC.X + 1, block.BlockC.Y] < 2)
                {
                    block.BlockMiddle.X += 1;
                    block.BlockA.X += 1;
                    block.BlockB.X += 1;
                    block.BlockC.X += 1;
                    updateGameField();
                }
            }
        }
    }
}
