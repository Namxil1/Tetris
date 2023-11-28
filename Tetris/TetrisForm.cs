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
            //game = new TetrisGame(this);
            gameActive = false;
        }
        private void DrawBlock(int x, int y,Color color)
        {
            Graphics g = panelGame.CreateGraphics();
            Brush brush = new SolidBrush(color);
            int cellSize = 40;
            g.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);
        }
        public void PlaceBlock(int x, int y, int colorCode)
        {
            Color color;
            switch (colorCode)
            {
                case 0:
                    color = Color.Black;
                    break;
                case 1:
                    color = Color.Red;
                    break;
                case 2:
                    color = Color.Blue;
                    break;
                case 3:
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
                    PlaceBlock(x, y, 0);
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
            //PlaceBlock(0, 1, 2);
            //PlaceBlock(5, 10,2);
            //PlaceBlock(5, 0,3);
            game = new TetrisGame(this);
            GameTimer.Enabled = true;
            gameActive = true;
        }
        private void TetrisForm_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (gameActive)
            {
                if ( e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    game.moveLeft();
                }
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    game.moveRight();
                }
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                {
                    game.downByOne();
                }
            }
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
