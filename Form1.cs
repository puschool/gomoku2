using Gomoku;

namespace 五子棋
{
    public partial class Form1 : Form
    {
       
        private Game game = new Game();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);
                // 檢查是否有人獲勝
                if (game.Winner == PieceType.BLACK)
                {
                   MessageBox.Show("黑色獲勝","遊戲結束");
                    this.Close();

                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白色獲勝", "遊戲結束");
                    this.Close();

                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}