using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        Board b = new Board();
        public bool Win = false;
        Piecetype nexttype = Piecetype.BLACK;
        List<Control> dynamic = new List<Control>();
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Win)
            {
                Piece piece = b.placepeice(e.X, e.Y, nexttype);


                if (piece != null)
                {
                    this.Controls.Add(piece);
                    dynamic.Add(piece);
                    if (b.Winner == Piecetype.BLACK)
                    {
                        MessageBox.Show("BLACK WIN!");
                        Win = true;
                    }
                    else if (b.Winner == Piecetype.WHITE)
                    {
                        MessageBox.Show("WHITE WIN!");
                        Win = true;
                    }



                    if (nexttype == Piecetype.BLACK)
                        nexttype = Piecetype.WHITE;
                    else
                        nexttype = Piecetype.BLACK;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (b.canplaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           foreach(Control ctrl in dynamic)
            {
                this.Controls.Remove(ctrl);
                Win = false;
                b = new Board();
            }
        }
    }
}
