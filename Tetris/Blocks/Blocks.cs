﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Blocks
    {
        public Blocks() { }
        private Block blockMiddle = new Block();
        private Block blockA = new Block();
        private Block blockB = new Block();
        private Block blockC = new Block();

        public Block BlockMiddle { get => blockMiddle; set => blockMiddle = value; }
        public Block BlockA { get => blockA; set => blockA = value; }
        public Block BlockB { get => blockB; set => blockB = value; }
        public Block BlockC { get => blockC; set => blockC = value; }

        private void newBlockCube()
        {
            BlockMiddle.X = 5;
            BlockMiddle.Y = 0;
            BlockA.X = 4;
            BlockA.Y = 0;
            BlockB.X = 5;
            BlockB.Y = 1;
            BlockC.X = 4;
            BlockC.Y = 1;
        }
        private void newBlockL()
        {
            BlockMiddle.X = 5;
            BlockMiddle.Y = 1;
            BlockA.X = 4;
            BlockA.Y = 0;
            BlockB.X = 5;
            BlockB.Y = 0;
            BlockC.X = 5;
            BlockC.Y = 2;
        }

        private void newBlockT()
        {
            BlockMiddle.X = 4;
            BlockMiddle.Y = 0;
            BlockA.X = 3;
            BlockA.Y = 1;
            BlockB.X = 4;
            BlockB.Y = 1;
            BlockC.X = 5;
            BlockC.Y = 1;
        }

        private void newBlockJ()
        {
            BlockMiddle.X = 4;
            BlockMiddle.Y = 0;
            BlockA.X = 5;
            BlockA.Y = 0;
            BlockB.X = 4;
            BlockB.Y = 1;
            BlockC.X = 4;
            BlockC.Y = 2;
        }

        private void newBlockI()
        {
            BlockMiddle.X = 5;
            BlockMiddle.Y = 2;
            BlockA.X = 5;
            BlockA.Y = 1;
            BlockB.X = 5;
            BlockB.Y = 0;
            BlockC.X = 5;
            BlockC.Y = 3;
        }

        private void newBlockZ()
        {
            BlockMiddle.X = 5;
            BlockMiddle.Y = 1;
            BlockA.X = 5;   
            BlockA.Y = 0;
            BlockB.X = 4;
            BlockB.Y = 0;
            BlockC.X = 6;
            BlockC.Y = 1;
        }

        private void newBlockS()
        {
            BlockMiddle.X = 5;
            BlockMiddle.Y = 1;
            BlockA.X = 5;
            BlockA.Y = 0;
            BlockB.X = 6;
            BlockB.Y = 0;
            BlockC.X = 4;
            BlockC.Y = 1;
        }

        public void newRandomBlock()
        {
            Random r = new Random();
            switch(r.Next(0, 7))
            {
                case 0: 
                    newBlockCube();
                    break;
                case 1:
                    newBlockL();
                    break;
                case 2:
                    newBlockT();
                    break;
                case 3:
                    newBlockJ();
                    break;
                case 4:
                    newBlockI();
                    break;
                case 5:
                    newBlockZ();
                    break;
                case 6:
                    newBlockS();
                    break;

            }
        }

    }
}
