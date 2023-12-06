using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        Boolean gameActive;
        TetrisGame game;
        private Graphics g;
        private Bitmap buffer;
        private Graphics bufferG;
        
        public int Score { get => Convert.ToInt32(textBoxScore.Text); set => textBoxScore.Text = value.ToString(); }
        public int Intervall { get => GameTimer.Interval; set => GameTimer.Interval = value; }

        public TetrisForm()
        {
            InitializeComponent();
            gameActive = false;
            g = panelGame.CreateGraphics();
            buffer = new Bitmap(panelGame.Width, panelGame.Height);
            bufferG = Graphics.FromImage(buffer);
        }
        

        private void DrawBlock(int x, int y, Color color)
        {
            int cellSize = 40;

            // Zeichne den gefüllten Block
            Brush blockBrush = new SolidBrush(color);
            bufferG.FillRectangle(blockBrush, x * cellSize, y * cellSize, cellSize, cellSize);

            // Zeichne das Gitter
            Pen gridPen = new Pen(Color.White);

            bufferG.DrawRectangle(gridPen, x * cellSize, y * cellSize, cellSize, cellSize);
            
        }
        public void UpdateGamePanel()
        {
            g.DrawImage(buffer, 0, 0);
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
                    color = Color.Purple;
                    break;
                case 4:
                    color = Color.DarkGreen;
                    break;
                case 5:
                    color = Color.Yellow;
                    break;
                case 6:
                    color = Color.Green;
                    break;
                case 7:
                    color = Color.Orange;
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
        private void buttonRestartGame_Click(object sender, EventArgs e)
        {
            ResetGameField();
            game = new TetrisGame(this);
            GameTimer.Enabled = true;
            GameTimer.Interval = 1500;
            gameActive = true;
            labelGameOver.Visible = false;
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
                else if (e.KeyCode == Keys.W)
                {
                    game.rotateBlock();
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

        public void GameOver()
        {
            GameTimer.Enabled = false;
            labelGameOver.Visible = true;
            gameActive = false;
        }


    }
}
