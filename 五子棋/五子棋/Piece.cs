using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace 五子棋
{
    abstract class Piece : PictureBox
    {
        public Piece (int x,int y)//piece constructor!
        {
            this.Location = new Point(x-25, y-25);
            this.Size = new Size(50, 50);
            //this.Image = Properties.Resources.black;
            this.BackColor = Color.Transparent;
        }
        public abstract Piecetype GetPiecetype();
    }
}
