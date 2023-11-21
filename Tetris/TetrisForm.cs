using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        int cellSize = 30;
        int gamewidth = 10;
        int gameheight = 20;
        
        public TetrisForm()
        {
            InitializeComponent();
            DrawGamefield();
        }

        private void PanelGame_Paint(object sender, PaintEventArgs e)
        {
            DrawGamefield();
        }

        private void DrawGamefield()
        {
            Graphics g = panelGame.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, gamewidth*cellSize, gameheight*cellSize));
            //Draw vertical Lines
            for (int x = 0; x <= gamewidth * cellSize; x += cellSize)
            {
                g.DrawLine(Pens.White, x, 0, x, gameheight * cellSize);
            }

            //Draw horizontal Lines
            for (int y = 0; y <= gameheight * cellSize; y += cellSize)
            {
                g.DrawLine(Pens.White, 0, y, gamewidth * cellSize, y);
            }
            g.Dispose();
        }
        
    }
}
