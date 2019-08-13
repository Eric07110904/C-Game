using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 打磚塊
{
    class Game
    {
        public static bool check_touch_bar(Ball ball,SlideBar bar)
        {
            if( (ball.Top+ball.Height >= bar.Top)&&(ball.Location.X<=bar.Location.X+bar.Width)&&(ball.Location.X>=bar.Location.X))
            {
                return true;
            }
            return false;
        }
        public static bool check_colid(Ball ball,Wall [,] wall ,int size,Form form)
        {
            int x = ball.Location.X;
            int y = ball.Location.Y;
            
           for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if (wall[i, j] == null)
                    {
                        continue;
                    }
                    int target_x = wall[i, j].Location.X;
                    int target_y = wall[i, j].Location.Y;

                    if ((x < target_x + 100 && x > target_x) && (y>target_y&&y<target_y+25))
                    {
                        form.Controls.Remove(wall[i, j]);
                        wall[i, j].Dispose();
                        wall[i, j] = null;
                        return true;
                    }

                }
            }
            return false;
        }
        public static bool check_lose(Ball ball,Form form,SlideBar bar)
        {
            if (ball.Location.Y >= bar.Location.Y+bar.Height+25)
            {
                return true;
            }

            return false;
        }
    }
}
