namespace 五子棋
{
    public partial class Form1 : Form
    {
        private bool isblack = true;
        public Form1()
        {
            InitializeComponent();
            //this.Controls.Add(new BlackPiece(35, 35));
            //this.Controls.Add(new WhitePiece(100, 200));
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
    }
}