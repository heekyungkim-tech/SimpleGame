using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstGame2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                picHero.Top -= 25;
            }
            else if (e.KeyCode == Keys.Down)
            {
                picHero.Top += 25;
            }

            if (picHero.Top < 0)
            {
                picHero.Top = 0;
            }
            else if (picHero.Top + picHero.Height > this.Height)
            {
                picHero.Top = this.Height - picHero.Height;
            }
        }
        private void picEnemy2_click(object sender, EventArgs e)
        {

        }
        private void picEnem3_click(object sender, EventArgs e)
        {

        }
        private void picEnemy1_click(object sender, EventArgs e)
        {

        }

        private Random r = new Random();
        private int Score = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[] enemies = new PictureBox[] { picEnemy1, picEnemy2, picEnemy3 };

            for (int i = 0; i < 3; i++)
            {
                enemies[i].Left -= 25 + (i * 10);
                if (enemies[i].Left <0)
                {

                   Score += 10;
                   lblScore.Text = "Score: " + Score.ToString();
                   enemies[i].Left = this.Width;
                   enemies[i].Top = (int)(r.NextDouble() * (this.Height - enemies[i].Height));
                }

                // possible collusion on horizontal axis?
	            if (enemies[i].Left < picHero.Left + picHero.Width)
                {
                    if ((enemies[i].Top >= picHero.Top && enemies[i].Top <= picHero.Bottom) ||
                        (enemies[i].Bottom >= picHero.Top && enemies[i].Bottom <= picHero.Bottom))
                    {
                        // we got a hit!
                        timer1.Enabled= false;
                        MessageBox.Show("Game Over!");
                        Score= 0;
                    }
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
