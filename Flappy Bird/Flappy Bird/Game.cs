using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }
        int PipeSpeed = 8;
        int Gravity = 15;
        int Score = 0;
        private void gameTimer(object sender, EventArgs e)
        {
            pictureBox_Bird.Top += Gravity;
            pictureBox_Bottom.Left -= PipeSpeed;
            pictureBox_top.Left -= PipeSpeed;
            label1.Text = Score.ToString();

            if (pictureBox_Bottom.Left < -150)
            {
                pictureBox_Bottom.Left = 800;
                Score++;
            }
            if (pictureBox_top.Left < -180)
            {
                pictureBox_top.Left = 950;
                Score++;
            }
            if (pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Bottom.Bounds)
                || pictureBox_Bird.Bounds.IntersectsWith(pictureBox_top.Bounds)
                    || pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Ground.Bounds)
                        || pictureBox_Bird.Top < -25)
            {
                EndGame();
            }
        }
        public void EndGame()
        {
            label2.Visible = true;
            timer_GameControl.Stop();
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            label2.Text = Score.ToString();
            
        }

        private void GameDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Gravity = -15;
            }
        }

        private void GameUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Gravity = 15;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            timer_GameControl.Enabled = true;
            pictureBox_top.Visible = true;
            pictureBox_Bottom.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
