using Gomoku;

namespace 五子棋
{
    public partial class Form1 : Form
    {

        private Game game = new Game();

        public Form1()
        {
            MessageBox.Show("本遊戲為五子棋使用9*9棋盤，操作方式為黑白棋各自輪流操作，直到贏者出現\n即結束遊戲！！\n" +
                "\n   靜宜資傳一A 程式設計C# 期末專題" +
                "\n   411212096 吳之涵   \n   411212127 蕭采容" +
                "\n  (411031301 韓婉晶)   ", "遊戲開始，本遊戲為普通級，不限年齡皆可參與~");
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
                    MessageBox.Show("黑棋獲勝", "遊戲結束");
                    this.Close(); //關閉視窗

                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白棋獲勝", "遊戲結束");
                    this.Close();  //關閉視窗

                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) //滑鼠移動時，需要做甚麼事件(會到這個事件)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;  // 游標變成手
            }
            else
            {
                this.Cursor = Cursors.Default;// 游標變成指標箭頭
            }
        }
    }
}