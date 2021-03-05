using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gametest
{
    class Dragon
    {
        private int x;//מיקום התמונה על ציר האיקס
        private int y;//מיקקום התמונה על ציר הוואי
        private Image[] pictures;//מערך תמונות שמתחלפות כל עמה זמן
        private int currentPicture;//משתנה השומר את התמונה הנמצאת על המסך ברגע זה
        private Timer changePicture;//טיימר שנמצא בוא הזמן בין כל שינוי תמונה
        private Timer pictureFall;//טיימר שמוריד את התמונה
        //-----------------------------------------------------------------------
        int time = 1;
        //--------------------------------------------------------------------------
        public Dragon(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.currentPicture = 0;
            this.pictures = new Image[5];
            this.pictures[0] = Resource.Dragon_1;
            this.pictures[1] = Resource.Dragon_2;
            this.pictures[2] = Resource.Dragon_3;
            this.pictures[3] = Resource.Dragon_4;
            this.pictures[4] = Resource.Dragon_5;
            

            this.changePicture=new Timer();
            this.changePicture.Interval = 100;//כמה זמן הטיימר פועל
            this.changePicture.Enabled = true;
            this.changePicture.Tick += changePicture_Tick;

            this.pictureFall = new Timer();
            this.pictureFall.Interval = 30;
            this.pictureFall.Enabled = true;
            this.pictureFall.Tick += pictureFall_Tick;
            
         }
        void pictureFall_Tick(object sender, EventArgs e)//למצוא פיתרון לתאוצה
        {
            time += 1 ;
            this.y += time;
            if (this.y +135 > 500 )
                time = -1;
            
        }
        //-----------------------------------------------------------------------
        void changePicture_Tick(object sender, EventArgs e)//איזה תמונה תוצג בכל הפעלה של טיימר
        {
            this.currentPicture++;
            if (this.currentPicture == 4)
                this.currentPicture = 0;


        }
        //-------------------------------------------------------------
        public void Show(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.pictures[this.currentPicture], new Rectangle(this.x,this.y,150,140));//מגביל את המקום הנתון לתמונה בפיקטיורבוקס
        }
        public void MoveUp()
        {
            if(this.y>-35)

            time =- 13;
            
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
