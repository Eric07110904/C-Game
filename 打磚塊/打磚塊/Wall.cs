using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace 打磚塊
{
    class Wall :PictureBox
    {
        public Wall(int x,int y)
        {
            this.BackColor = Color.Red;
            this.Width = 100;
            this.Height = 20;
            this.Location = new Point(x, y);
        }
    }
}
