using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace 打磚塊
{
    class Ball : PictureBox
    {
        public Ball(int x,int y)//constructor
        {
            Point temp = new Point(x, y);
            this.Width = 50;
            this.Height = 50;
            this.Image = Properties.Resources.black;
            this.BackColor = Color.Transparent;
            this.Location = temp;

        }
    }
}
