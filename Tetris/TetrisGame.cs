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
            form.PlaceBlock(block.BlockMiddle.X, block.BlockMiddle.Y,color);
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
                if (gameField[block.BlockMiddle.X-1, block.BlockMiddle.Y] == 0 && gameField[block.BlockA.X -1, block.BlockA.Y] == 0
                    && gameField[block.BlockB.X-1, block.BlockB.Y] == 0 && gameField[block.BlockC.X-1, block.BlockC.Y] == 0)
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

        public void rotateClockwise()
        {
            //public void rotateClockwise()
            //{
            //    // Speichern der aktuellen Positionen der Blöcke
            //    int middleX = block.BlockMiddle.X;
            //    int middleY = block.BlockMiddle.Y;
            //    int aX = block.BlockA.X;
            //    int aY = block.BlockA.Y;
            //    int bX = block.BlockB.X;
            //    int bY = block.BlockB.Y;
            //    int cX = block.BlockC.X;
            //    int cY = block.BlockC.Y;

            //    // Berechnung der neuen Positionen nach der Drehung um 90 Grad im Uhrzeigersinn
            //    block.BlockA.X = middleX + (middleY - aY);
            //    block.BlockA.Y = middleY - (middleX - aX);

            //    block.BlockB.X = middleX + (middleY - bY);
            //    block.BlockB.Y = middleY - (middleX - bX);

            //    block.BlockC.X = middleX + (middleY - cY);
            //    block.BlockC.Y = middleY - (middleX - cX);

            //    // Aktualisierung des Spielfelds
            //    updateGameField();
            //}

            //neueX = centerX + (alteY - centerY)
            //neueY = centerY - (alteX - centerX)

        }
    }
}
