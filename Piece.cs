using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;// 引用 PictureBox
using System.Drawing;

namespace 五子棋
{
    abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_WIDTH = 50;

        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - IMAGE_WIDTH /2 , y- IMAGE_WIDTH / 2);//建立一個點
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);

        }
        public abstract PieceType GetPieceType();
    }
}
