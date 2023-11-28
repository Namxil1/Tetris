using System;
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
        public void newRandomBlock()
        {
            Random r = new Random();
            switch(r.Next(0, 1))
            {
                case 0:
                    newBlockCube(); 
                    break;
                
            }
        }

    }
}
