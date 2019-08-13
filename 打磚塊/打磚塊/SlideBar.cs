using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace 打磚塊
{
    class SlideBar : PictureBox
    {
        public SlideBar(int x,int y)//constructor
        {
            Point temp = new Point(x, y);
            this.BackColor = Color.Black;
            this.Width = 116;this.Height = 16;
            this.Location = temp;
        }
    }
}
