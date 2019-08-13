using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace 打磚塊
{
    public partial class Form1 : Form
    {
        Ball ball = new Ball(380, 150);
        SlideBar bar = new SlideBar(306, 387);
        Wall  [,] wall = new Wall[5,5];
        
       
        public int vert_dir = 1;
        public int horz_dir = 1;
        public int speed = 6;
        public Form1()
        {
            InitializeComponent();
            //create ball
       
            this.Controls.Add(ball);
            this.Controls.Add(bar);
            for(int i = 0; i < 5; i++)
            {
                int w = 100;
                for(int j = 0; j < 5; j++)
                {
                    wall[i,j]= new Wall(100+w*j+j*6,14+26*i);
                    this.Controls.Add(wall[i, j]);
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ball.Top <0)
            {
                horz_dir = 1;
            }
            /*
            else if (ball.Top >= this.Height - ball.Height - 25)
            {
                horz_dir = -1;
            }
            */
            ball.Top += (speed * horz_dir);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ball location " + ball.Location.X + " " + ball.Location.Y + " left " + ball.Left);
            horz.Enabled = true;//start timer (let ball down)
            vert.Enabled = true;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {   
            //just move X cord
            bar.Location = new Point(e.X,bar.Location.Y);
        }

        private void Vert_Tick(object sender, EventArgs e)
        {
            if (ball.Left < 0)
            {
                vert_dir = 1;
            }
            else if (ball.Left >= this.Width -ball.Width)
            {
                vert_dir = -1;
            }
            ball.Left += (speed * vert_dir);
        }

        private void Check_Tick(object sender, EventArgs e)
        {
            if (Game.check_touch_bar(ball, bar))
            {
                //MessageBox.Show("touch!");
                
                vert_dir *= 1;//謎之設定
                horz_dir *= -1;
                
            }
            if(Game.check_colid(ball, wall, 5, this))
            {
                horz_dir *= -1;
                
            }
            if (Game.check_lose(ball, this,bar))
            {
                vert.Enabled = false;
                horz.Enabled = false;
                check.Enabled = false;
                label1.Text = "遊戲結束~";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
         
       
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
