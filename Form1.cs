namespace 五子棋
{
    public partial class Form1 : Form
    {
        private Board board = new Board();
        private PieceType nextPieceType = PieceType.BLACK;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = board.PlaceAPiece(e.X, e.Y, nextPieceType);
            if (piece != null)
            {
                this.Controls.Add(piece);
                if (nextPieceType == PieceType.BLACK)
                {
                    nextPieceType = PieceType.WHITE;
                }
                else if (nextPieceType == PieceType.WHITE)
                {
                    nextPieceType = PieceType.BLACK;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
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