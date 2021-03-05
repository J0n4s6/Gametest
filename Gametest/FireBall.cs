using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gametest
{
    class FireBall
    {
        private int x;
        private int y;
        private Image[] Balls;
        private int currentBall;
        private Timer BallMove;
        //-----------------------------------------------------------
        public FireBall(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Balls = new Image[1];
            this.Balls[0] = Resource.FireBall;

            this.BallMove = new Timer();
            this.BallMove.Interval = 5;
            this.BallMove.Enabled = true;
            this.BallMove.Tick += BallMove_Tick;

       }

        void BallMove_Tick(object sender, EventArgs e)
        {
            this.currentBall++;
            if(this.currentBall==1)
                    this.currentBall=0;
            this.x += 10;
        }
        public void Show(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.Balls[0], new Rectangle(this.x, this.y, 50,30));
        }
        public int GetX()
        {
            return this.x;
        }
        public int GetY()
        {
            return this.y; 
        }
    }
}
