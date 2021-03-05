using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gametest
{
    public partial class 
        Form1 : Form
    {
        BackgroundMove woods; 
        Dragon fabulous;
        List<Obstacle> obstacles;
        private Timer AddObstacleTimer;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            this.fabulous = new Dragon(5, 5);
            this.woods = new BackgroundMove();
            this.obstacles = new List<Obstacle>();
            this.AddObstacleTimer = new Timer();
            this.AddObstacleTimer.Interval = 2000;
            this.AddObstacleTimer.Enabled = true;
            this.AddObstacleTimer.Tick += AddObstacleTimer_Tick;

        }

        void AddObstacleTimer_Tick(object sender, EventArgs e)
        {
            this.obstacles.Add(new Obstacle(1350,r.Next(450),(ObstacleType)r.Next(3)));
        }

    
       
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            fabulous.Show(e);
            for (int i = 0; i < this.obstacles.Count; i++)
            {
                this.obstacles[i].Show(e);
            }

            
         }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            fabulous.MoveUp();
            
        }
        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           

 
        }

        private void CrashTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.obstacles.Count; i++)
                if (this.obstacles[i].GetRectangleF().IntersectsWith(new RectangleF(fabulous.GetX(), fabulous.GetY(), 150, 140)))
                {
                    this.obstacles.RemoveAt(i);
                }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            woods.Show(e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


   
        


    

      
  
      
        
    }
}
