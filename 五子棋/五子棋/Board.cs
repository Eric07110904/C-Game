using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace 五子棋
{
    class Board
    {
        private int offset = 73;
        private int distance = 76;
        private int radius = 10;
        private Point error = new Point(-1, -1);
        private Piece[,] pieces = new Piece[9,9];
        private Point lastPlaced = new Point(-1, -1);
        public Piecetype winner = Piecetype.NONE;
        public Piecetype current = Piecetype.BLACK;
        public Piecetype Winner { get { return winner; } }
        public Point LastPlaced { get { return lastPlaced; } }
        public bool canplaced(int x,int y)
        {
            Point temp = findplaced(x, y);
            if (temp == error)
                return false;

            if (pieces[temp.X, temp.Y] != null)
            {
                return false;
            }

            //如果沒放過
            return true;
        }
        public Piece placepeice(int x,int y,Piecetype type)
        {
            Point temp = findplaced(x, y);
            Point ans = convertToForm(new Point(x, y));
            //MessageBox.Show(temp.X + " " + temp.Y);
            if (temp== error)
                return null ;

            //根據 piecetype 產生對應的旗子
            if (pieces[temp.X, temp.Y] != null)//已經有旗子
            {
                return null;
                //已經有棋子了
            }
            lastPlaced = temp;
            checkWinner();
            if (type == Piecetype.BLACK)
            {
                pieces[temp.X, temp.Y] = new Black(ans.X, ans.Y);
                current = Piecetype.WHITE;
            }
            else
            {
                pieces[temp.X, temp.Y] = new White(ans.X, ans.Y);
                current = Piecetype.BLACK;
            }
     
            return pieces[temp.X, temp.Y];
        }
        public Point findplaced(int x,int y)
        {
            int nodex = findplaced(x);
            int nodey = findplaced(y);
            if (nodex == -1)//沒找到
                return error;

            if (nodey == -1)
                return error;

            
            return new Point(nodex, nodey);

        }

        public int findplaced(int x)
        {
            if (x < offset)
                return -1;
            int dis = (x - offset)/distance;
            int dis2 = (x - offset) % distance;
            if (dis2 <= radius)
            {
                return dis;
            }
            else if (dis2 >= distance - radius)
                return dis + 1;
            else
                return -1;
        }
        public Point convertToForm(Point youclick)
        {
            Point ans = findplaced(youclick.X, youclick.Y);
            if (ans == error)
                return error;
            int disx = offset + distance * ans.X;
            int disy = offset + distance * ans.Y;

            return new Point(disx, disy);
        }
        public Piecetype getType(int x,int y)
        {
            if (pieces[x, y] == null)
                return Piecetype.NONE;
            else
                return pieces[x, y].GetPiecetype();
        }
        public void checkWinner()
        {
            int centx = LastPlaced.X;
            int centy = LastPlaced.Y;
            int count = 1;
            for(int dirx = -1; dirx <= 1; dirx++)
            {
                for(int diry = -1; diry <= 1; diry++)
                {
                    if (dirx == 0 && diry == 0)
                    {
                        continue;
                    }
                    count = 1;int sum = 1;
                    for (int i = 1; i >=-1; i-=2)
                    {
                        if (i == -1)
                        {
                            //sum -= 1;
                            count = 1;
                            
                        }
                            
                        while (sum < 5)
                        {
                           
                            int targetx = centx + count * dirx*i;
                            int targety = centy + count * diry*i;
                            if (targetx < 0 || targety < 0 || targetx > 8 || targety > 8)
                                break;
                            if (getType(targetx, targety) != current)
                                break;
                            sum++;
                            count++;
                        }

                        if (sum == 5)
                        {
                            winner = current;
                            
                        }
                        
                    }
                }
            }
            
        }
    }
   
}
