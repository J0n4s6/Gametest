using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gametest
{
    class BackgroundMove
    {
        private int x;
        private int y;
        private Image Background;
        private Timer BackMove;
        //--------------------------------------------------
        public BackgroundMove()
        {
            this.x = 0;
            this.y = 0;
            this.Background = Resource.JungleBackground;
           

            this.BackMove = new Timer();
            this.BackMove.Interval = 1;
            this.BackMove.Enabled = true;
            this.BackMove.Tick += BackMove_Tick;      
        }

        void BackMove_Tick(object sender, EventArgs e)
        {
            this.x -=2 ;
            if (x <= -1300)
                this.x += 1300;

        }
        public void Show(PaintEventArgs e)
        {
            //e.Graphics.DrawImage(this.Background, new Point(x, y));
            //e.Graphics.DrawImage(this.Background, new Point(x+this.Background.Width, y));
            e.Graphics.DrawImage(this.Background,new Rectangle(this.x,this.y,1300,500));
            e.Graphics.DrawImage(this.Background, new Rectangle(this.x+1297, this.y, 1300, 500));
        }
    }
}
