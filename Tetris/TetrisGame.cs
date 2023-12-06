using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
//Hallo
{
    internal class TetrisGame
    {
        private TetrisForm form;
        Blocks block;
        private int[,] gameField;
        private int color = 1;
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
            Random random = new Random();
            color = random.Next(1, 7);
        }
        private void ClearRows()
        {
            int rowsCleared = 0;
            for (int y = 0; y < 22; y++)
            {
                bool isRowFull = true;

                //Check ob Reihe voll
                for (int x = 0; x < 10; x++)
                {
                    if (gameField[x, y] == 0)
                    {
                        isRowFull = false;
                        break;
                    }
                }

                if (isRowFull)
                {
                    rowsCleared++;
                    //Reihe leeren
                    for (int x = 0; x < 10; x++)
                    {
                        gameField[x, y] = 0;
                    }
                    //Alle Reihen runter
                    for (int i = y - 1; i >= 0; i--)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            gameField[x, i + 1] = gameField[x, i];
                        }
                    }
                }
            }
            if (rowsCleared ==1)
            {
                form.Score +=40;
                if (form.Intervall > 250)
                {
                    form.Intervall -= new Random().Next(1, 15);
                }
            }
            else if (rowsCleared == 2)
            {
                form.Score += 100;
                if (form.Intervall > 250)
                {
                    form.Intervall -= new Random().Next(5, 20);
                }
            }
            else if (rowsCleared == 3)
            {
                form.Score += 300;
                if (form.Intervall > 250)
                {
                    form.Intervall -= new Random().Next(10, 25);
                }
            }
            else if (rowsCleared == 4)
            {
                form.Score += 1200;
                if (form.Intervall > 250)
                {
                    form.Intervall -= new Random().Next(10, 30);
                }
            }
            
        }

        private void updateGameField()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 22; y++)
                {
                    form.PlaceBlock(x, y, gameField[x, y]);
                }
            }
            form.PlaceBlock(block.BlockMiddle.X, block.BlockMiddle.Y, color);
            form.PlaceBlock(block.BlockA.X, block.BlockA.Y, color);
            form.PlaceBlock(block.BlockB.X, block.BlockB.Y, color);
            form.PlaceBlock(block.BlockC.X, block.BlockC.Y, color);
            form.UpdateGamePanel();
        }

        public void downByOne()
        {
            if (block.BlockMiddle.Y < 21 && block.BlockA.Y < 21 && block.BlockB.Y < 21 && block.BlockC.Y < 21)
            {
                if (gameField[block.BlockMiddle.X, block.BlockMiddle.Y + 1] == 0 && gameField[block.BlockA.X, block.BlockA.Y + 1] == 0
                    && gameField[block.BlockB.X, block.BlockB.Y + 1] == 0 && gameField[block.BlockC.X, block.BlockC.Y + 1] == 0)
                {
                    block.BlockMiddle.Y += 1;
                    block.BlockA.Y += 1;
                    block.BlockB.Y += 1;
                    block.BlockC.Y += 1;
                }
                else
                {
                    gameField[block.BlockMiddle.X, block.BlockMiddle.Y] = color;
                    gameField[block.BlockA.X, block.BlockA.Y] = color;
                    gameField[block.BlockB.X, block.BlockB.Y] = color;
                    gameField[block.BlockC.X, block.BlockC.Y] = color;
                    newBlock();
                }
            }
            else
            {
                gameField[block.BlockMiddle.X, block.BlockMiddle.Y] = color;
                gameField[block.BlockA.X, block.BlockA.Y] = color;
                gameField[block.BlockB.X, block.BlockB.Y] = color;
                gameField[block.BlockC.X, block.BlockC.Y] = color;
                newBlock();
            }
            updateGameField();
        }

        public void moveLeft()
        {
            if (block.BlockMiddle.X > 0 && block.BlockA.X > 0 && block.BlockB.X > 0 && block.BlockC.X > 0)
            {
                if (gameField[block.BlockMiddle.X - 1, block.BlockMiddle.Y] == 0 && gameField[block.BlockA.X - 1, block.BlockA.Y] == 0
                    && gameField[block.BlockB.X - 1, block.BlockB.Y] == 0 && gameField[block.BlockC.X - 1, block.BlockC.Y] == 0)
                {
                    block.BlockMiddle.X -= 1;
                    block.BlockA.X -= 1;
                    block.BlockB.X -= 1;
                    block.BlockC.X -= 1;
                    updateGameField();
                }
            }
        }

        public void moveRight()
        {
            if (block.BlockMiddle.X < 9 && block.BlockA.X < 9 && block.BlockB.X < 9 && block.BlockC.X < 9)
            {
                if (gameField[block.BlockMiddle.X + 1, block.BlockMiddle.Y] == 0 && gameField[block.BlockA.X + 1, block.BlockA.Y] == 0
                    && gameField[block.BlockB.X + 1, block.BlockB.Y] == 0 && gameField[block.BlockC.X + 1, block.BlockC.Y] == 0)
                {
                    block.BlockMiddle.X += 1;
                    block.BlockA.X += 1;
                    block.BlockB.X += 1;
                    block.BlockC.X += 1;
                    updateGameField();
                }
            }
        }

        public void rotateBlock()
        {
            Blocks relative = new Blocks();
            relative.BlockA.X = block.BlockA.X - block.BlockMiddle.X;
            relative.BlockA.Y = block.BlockA.Y - block.BlockMiddle.Y;

            relative.BlockB.X = block.BlockB.X - block.BlockMiddle.X;
            relative.BlockB.Y = block.BlockB.Y - block.BlockMiddle.Y;

            relative.BlockC.X = block.BlockC.X - block.BlockMiddle.X;
            relative.BlockC.Y = block.BlockC.Y - block.BlockMiddle.Y;

            // Rotationsformel anwenden
            int tempX;

            // BlockA rotieren
            tempX = relative.BlockA.X;
            relative.BlockA.X = -relative.BlockA.Y;
            relative.BlockA.Y = tempX;

            // BlockB rotieren
            tempX = relative.BlockB.X;
            relative.BlockB.X = -relative.BlockB.Y;
            relative.BlockB.Y = tempX;

            // BlockC rotieren
            tempX = relative.BlockC.X;
            relative.BlockC.X = -relative.BlockC.Y;
            relative.BlockC.Y = tempX;

            relative.BlockA.X = relative.BlockA.X + block.BlockMiddle.X;
            relative.BlockA.Y = relative.BlockA.Y + block.BlockMiddle.Y;

            relative.BlockB.X = relative.BlockB.X + block.BlockMiddle.X;
            relative.BlockB.Y = relative.BlockB.Y + block.BlockMiddle.Y;

            relative.BlockC.X = relative.BlockC.X + block.BlockMiddle.X;
            relative.BlockC.Y = relative.BlockC.Y + block.BlockMiddle.Y;
            if (relative.BlockA.X >= 0 && relative.BlockA.X <= 9
            && relative.BlockA.Y >= 0 && relative.BlockA.Y <= 21
            && relative.BlockB.X >= 0 && relative.BlockB.X <= 9
            && relative.BlockB.Y >= 0 && relative.BlockB.Y <= 21
            && relative.BlockC.X >= 0 && relative.BlockC.X <= 9
            && relative.BlockC.Y >= 0 && relative.BlockC.Y <= 21)
            {
                if (gameField[relative.BlockA.X, relative.BlockA.Y] == 0 && gameField[relative.BlockB.X, relative.BlockB.Y] == 0
                    && gameField[relative.BlockC.X, relative.BlockC.Y] == 0)
                {
                    block.BlockA = relative.BlockA;
                    block.BlockB = relative.BlockB;
                    block.BlockC = relative.BlockC;
                    updateGameField();
                }
            }
        }
    }
}
