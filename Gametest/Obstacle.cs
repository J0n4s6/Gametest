using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gametest
{
    class Obstacle
    {
        private Image[] pictures;//מערך של כמה תמונות
        private int currentPicture;
        private RectangleF rec;//תיחום של תמונה
        private ObstacleType type;//סוג אובייקט
        private Timer MovePictureTimer;//תנועה של גוף
        private Timer ChangePictureTimer;//שינוי תמונה של גוף
        //--------------------------------------------------------------
        public Obstacle(int x, int y,ObstacleType type)
        {
            this.rec=new Rectangle(x,y,70,45);
            this.type = type;
            this.pictures = new Image[10];
            this.currentPicture=0;
            switch(this.type)
            {
                case(ObstacleType.heart):
                    this.pictures[0] = Resource.Heart1;
                    this.pictures[1] = Resource.Heart1;
                    this.pictures[2] = Resource.Heart1;
                    this.pictures[3] = Resource.Heart1;
                    this.pictures[4] = Resource.Heart1;
                    this.pictures[5] = Resource.Heart2;
                    this.pictures[6] = Resource.Heart2;
                    this.pictures[7] = Resource.Heart2;
                    this.pictures[8] = Resource.Heart2;
                    this.pictures[9] = Resource.Heart2; break;

                case(ObstacleType.coin):
                    this.pictures[0] = Resource.Coin_1;
                    this.pictures[1] = Resource.Coin_2;
                    this.pictures[2] = Resource.Coin_3;
                    this.pictures[3] = Resource.Coin_4;
                    this.pictures[4] = Resource.Coin_5;
                    this.pictures[5] = Resource.Coin_6;
                    this.pictures[6] = Resource.Coin_7;
                    this.pictures[7] = Resource.Coin_8;
                    this.pictures[8] = Resource.Coin_9;
                    this.pictures[9] = Resource.Coin_10; break;
                    
                case(ObstacleType.bomb):
                    this.pictures[0] = Resource.Bomb_1;
                    this.pictures[1] = Resource.Bomb_1;
                    this.pictures[2] = Resource.Bomb_1;
                    this.pictures[3] = Resource.Bomb_1;
                    this.pictures[4] = Resource.Bomb_1;
                    this.pictures[5] = Resource.Bomb_2;
                    this.pictures[6] = Resource.Bomb_2;
                    this.pictures[7] = Resource.Bomb_2;
                    this.pictures[8] = Resource.Bomb_2;
                    this.pictures[9] = Resource.Bomb_2; break;
                    
            }

            this.ChangePictureTimer = new Timer();
            this.ChangePictureTimer.Interval = 50;//כל כמה זמן הטיימר פועל 
            this.ChangePictureTimer.Enabled = true;
            this.ChangePictureTimer.Tick += ChangePictureTimer_Tick;

            this.MovePictureTimer = new Timer();
            this.MovePictureTimer.Interval = 1;
            this.MovePictureTimer.Enabled = true;
            this.MovePictureTimer.Tick += MovePictureTimer_Tick;   
            
        }

        void MovePictureTimer_Tick(object sender, EventArgs e)
        {
            this.rec.X -=2;
        }

        void ChangePictureTimer_Tick(object sender, EventArgs e)
        {
            this.currentPicture++;
            if (this.currentPicture == 9)
                this.currentPicture = 0;
        }

        public void Show(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.pictures[this.currentPicture],rec);
        }

        public RectangleF GetRectangleF()
         {
             return this.rec;
         }
    }
    public enum ObstacleType
    {
        heart,coin,bomb,
    }
}
