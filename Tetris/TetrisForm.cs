using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        Boolean gameActive;
        TetrisGame game;
        public TetrisForm()
        {
            InitializeComponent();
            game = new TetrisGame();
            gameActive = false;
        }
        private void DrawBlock(int x, int y,Color color)
        {
            Graphics g = panelGame.CreateGraphics();
            Brush brush = new SolidBrush(color);
            int cellSize = 40;
            g.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);
        }
        //private void InitializeIBlock()
        //{
        //    TetrisBlock[] iBlock =
        //    {
        //        new TetrisBlock(new Point(0, 0), Color.LightBlue),
        //        new TetrisBlock(new Point(1, 0), Color.LightBlue),
        //        new TetrisBlock(new Point(2, 0), Color.LightBlue),
        //        new TetrisBlock(new Point(3, 0), Color.LightBlue),
        //    };
        //    foreach (var block in iBlock)
        //    {
        //        Controls.Add(block.PictureBox);
        //    }
        //}

        public void PlaceBlock(int x, int y, string colorCode)
        {
            Color color;
            switch (colorCode)
            {
                case "B":
                    color = Color.Blue;
                    break;
                case "R":
                    color = Color.Red;
                    break;
                case "Schwarz":
                    color = Color.Black;
                    break;
                case "W":
                    color = Color.White;
                    break;
                default:
                    throw new ArgumentException("Wrong Color");
            }
            DrawBlock (x, y, color);
        }

        public void ResetGameField()
        {
            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    PlaceBlock(x, y, "Schwarz");
                }
            }
        }
        private void CenterPanel()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int panelWidth = panelGame.Width;
            int panelHeight = panelGame.Height;

            int x = (screenWidth - panelWidth) / 2;
            int y = (screenHeight - panelHeight) / 2;

            panelGame.Location = new Point(x, y);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ResetGameField();
            PlaceBlock(0, 1, "B");
            PlaceBlock(5, 10,"R");
            PlaceBlock(7, 15,"W");
        }

        private void TetrisForm_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameActive)
            {
                game.nextTick();
            }
        }
    }
}
