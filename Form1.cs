namespace 五子棋
{
    public partial class Form1 : Form
    {
        private Board board = new Board();
        private bool isblack = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isblack)
            {
                this.Controls.Add(new BlackPiece(e.X, e.Y));
                isblack = false;
            }
            else
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y));
                isblack = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(board.CanBePlaced(e.X, e.Y))
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