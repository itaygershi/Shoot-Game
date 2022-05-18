﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Shoot_Game
{
    class Bullet
    {
        public string direction;
        public int bulletsLeft;
        public int bulletsTop;

        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer= new Timer();

        public void MakeBullet(Form form)
        {

            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletsLeft;
            bullet.Top = bulletsTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();

        }

        private void BulletTimerEvent(object sender , EventArgs e)
        {
            if (direction=="left")
            {
                bullet.Left -= speed;
            }
            if (direction == "right")
            {
                bullet.Left += speed;
            }
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bullet.Left < 10 || bullet.Left > 1500/*860*/ || bullet.Top < 10 || bullet.Top > 1500/*600*/) 
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }


        }
    }
}
