using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoot_Game
{


    public partial class Form1 : Form
    {
        List<PictureBox> zombiesList = new List<PictureBox>();
        List<PictureBox> aliensList = new List<PictureBox>();

        Soldier soldier = new Soldier();
        Zombie zombie = new Zombie();
        Alien alien = new Alien();
        PictureBox player_PictureBox;
        //PictureBox zombie = new PictureBox();
       
        int ammo = 10;

        int score;
        Random randNum = new Random();

        public Form1()
        {

            InitializeComponent();
            RestartGame();
        }
        
        public void print_to_text_box(string x) 
        {
            textBox.Text += x;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {

           

            player_PictureBox = soldier.create_soldier_PictureBox();

            if (soldier.live_or_dead())
            {
                healthBar.Value = soldier.get_health();
            }
            else
            {

                player.Image = Properties.Resources.dead;
                soldier.gameOver = true;
                GameTimer.Stop();
            }

            txtAmmo.Text = "Ammo: " + ammo;
            txtScore.Text = "Kills: " + score;
            if (soldier.goLeft == true && player.Left > 0)
            {
                player.Left -= soldier.get_speed();
            }
            if (soldier.goRight == true && player.Left + player.Width < this.ClientSize.Width - 160)
            {
                player.Left += soldier.get_speed();
            }
            if (soldier.goUp == true && player.Top > 45)
            {
                player.Top -= soldier.get_speed();
            }
            if (soldier.goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += soldier.get_speed();
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        soldier.set_health(zombie.get_damage());//zombie damage player
                    }
                    if (x.Left > player.Left)
                    {
                        x.Left -= zombie.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += zombie.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= zombie.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += zombie.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }
                }




                if (x is PictureBox && (string)x.Tag == "Alien")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        soldier.set_health(alien.get_damage());//alien damage player
                    }
                    if (x.Left > player.Left)
                    {
                        x.Left -= alien.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.Alien;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += alien.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.Alien;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= alien.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.Alien;
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += alien.get_speed();
                        ((PictureBox)x).Image = Properties.Resources.Alien;
                    }
                }


                if (score % 10 == 0 && score != 0)
                {
                    MakeAlien();
                }


                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies();

                        }
                    }

                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "Alien")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            alien.set_damage_to_health(soldier.get_damage());

                            if (alien.get_health() == 0)
                            {
                                score += 5;
                                this.Controls.Remove(j);
                                ((PictureBox)x).Dispose();
                                aliensList.Remove(((PictureBox)x));
                                alien.set_health(5); //set health to 5

                            }
                            else
                            {
                               // alien.set_damage_to_health(soldier.get_damage());
                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (soldier.get_gameOver() == true)
            {
                return;
            }
            if (e.KeyCode == Keys.Left)
            {
                soldier.set_goLeft(true);
                soldier.facing = "left";
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                soldier.set_goRight(true);
                soldier.facing = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                soldier.set_goUp(true);
                soldier.facing = "up";
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                soldier.set_goDown(true);
                soldier.facing = "down";
                player.Image = Properties.Resources.down;
            }



        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                soldier.goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                soldier.goRight = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                soldier.goUp = false;

            }
            if (e.KeyCode == Keys.Down)
            {
                soldier.goDown = false;

            }
            if (e.KeyCode == Keys.Space && ammo > 0 && soldier.gameOver == false)
            {
                ammo--;
                ShooteBullet(soldier.facing);


                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
            if (e.KeyCode == Keys.Enter && soldier.gameOver == true)
            {
                RestartGame();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ShooteBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletsLeft = player.Left + (player.Width / 2);
            shootBullet.bulletsTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);


        }

        private void Form1_BackgroundImageLayoutChanged(object sender, EventArgs e)
        {

        }

        private void MakeZombies()
        {
            Zombie zombie1 = new Zombie();
            //if(zombie1 != null)
            //{
            //    textBox.Text += "\n zombie constractor.";
            //}

            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.BackColor = Color.Transparent;
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;

            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();
            


            //zombie zomb = new zombie();

            //zombie = zomb.create_zombie_PictureBox();
            //zombie.Left = randNum.Next(0, 900);
            //zombie.Top = randNum.Next(0, 800);

            //zombiesList.Add(zombie);
            //this.Controls.Add(zombie);
            //player.BringToFront();
        }

        private void MakeAlien()
        {
            Alien alien = new Alien();
            if (alien != null)
            {
                textBox.Text += "\n alien constractor.";
            }

            PictureBox Alien = new PictureBox();
            Alien.Tag = "Alien";
            Alien.Image = Properties.Resources.zdown;
            Alien.BackColor = Color.Transparent;
            Alien.Left = randNum.Next(0, 900);
            Alien.Top = randNum.Next(0, 800);
            Alien.SizeMode = PictureBoxSizeMode.Zoom;

            aliensList.Add(Alien);
            this.Controls.Add(Alien);
            player.BringToFront();
            score++;
           

            //Alien ali = new Alien();
            //PictureBox alien = ali.create_alien_PictureBox();

            //aliensList.Add(alien);
            //this.Controls.Add(alien);
            //player.BringToFront();
            //score++;
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10,600 /*this.ClientSize.Width - ammo.Width*/);
            ammo.Top = randNum.Next(60,600 /*this.ClientSize.Width - ammo.Height*/);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void RestartGame()
        {
            player.Image = Properties.Resources.up;
            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }

            foreach (PictureBox i in aliensList)
            {
                this.Controls.Remove(i);
            }

            aliensList.Clear();

            zombiesList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZombies();
            }

            //if (score % 10 == 0)
            //{
            //    for (int j = 0; j < 1; j++)
            //    {

            //        MakeAlien();

            //    }
            //}

            soldier.goDown = false;
            soldier.goLeft = false;
            soldier.goRight = false;
            soldier.goUp = false;
            soldier.gameOver = false;

            soldier.set_new_health(100);//resat to full health
            score = 0;
            ammo = 10;

            GameTimer.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}










//using system;
//using system.collections.generic;
//using system.componentmodel;
//using system.data;
//using system.drawing;
//using system.linq;
//using system.text;
//using system.threading.tasks;
//using system.windows.forms;

//namespace shoot_game
//{
//    public partial class form1 : form
//    {
//        bool goleft, goright, goup, godown, gameover;
//        string facing = "up";
//        int playerhealth = 100;
//        int speed = 10;
//        int ammo = 10;
//        int zombiespeed = 3;
//        int alienhealth = 3;
//        int zombiehealth = 1;
//        /// <summary>
//        /// //////////////////////////////////////////
//        /// </summary>
//        int alienspeed = 1;
//        /// <summary>
//        /// ///////////////////////////////////////////
//        /// </summary>

//        int score;
//        random randnum = new random();

//        list<picturebox> zombieslist = new list<picturebox>();




//        /// ////////////////////////////////////////////////////////////////////
//        list<picturebox> alienlist = new list<picturebox>();
//        /// ///////////////////////////////////////////////////////////////////

//        public form1()
//        {
//            initializecomponent();
//            restartgame();
//        }

//        private void label1_click(object sender, eventargs e)
//        {

//        }

//        private void maintimerevent(object sender, eventargs e)
//        {
//            if (playerhealth > 1)
//            {
//                healthbar.value = playerhealth;
//            }
//            else
//            {
//                gameover = true;
//                player.image = properties.resources.dead;
//                gametimer.stop();
//            }
//            txtammo.text = "ammo: " + ammo;
//            txtscore.text = "kills: " + score;

//            if (goleft == true && player.left > 0)
//            {
//                player.left -= speed;
//            }
//            if (goright == true && player.left + player.width < this.clientsize.width)
//            {
//                player.left += speed;
//            }
//            if (goup == true && player.top > 45)
//            {
//                player.top -= speed;
//            }
//            if (godown == true && player.top + player.height < this.clientsize.height)
//            {
//                player.top += speed;
//            }

//            foreach (control x in this.controls)
//            {
//                if (x is picturebox && (string)x.tag == "ammo")
//                {
//                    if (player.bounds.intersectswith(x.bounds))
//                    {
//                        this.controls.remove(x);
//                        ((picturebox)x).dispose();
//                        ammo += 5;
//                    }
//                }

//                if (x is picturebox && (string)x.tag == "zombie")
//                {
//                    if (player.bounds.intersectswith(x.bounds))
//                    {
//                        playerhealth -= 1;
//                    }
//                    if (x.left > player.left)
//                    {
//                        x.left -= zombiespeed;
//                        ((picturebox)x).image = properties.resources.zleft;
//                    }
//                    if (x.left < player.left)
//                    {
//                        x.left += zombiespeed;
//                        ((picturebox)x).image = properties.resources.zright;
//                    }
//                    if (x.top > player.top)
//                    {
//                        x.top -= zombiespeed;
//                        ((picturebox)x).image = properties.resources.zup;
//                    }
//                    if (x.top < player.top)
//                    {
//                        x.top += zombiespeed;
//                        ((picturebox)x).image = properties.resources.zdown;
//                    }
//                }



//                /////////////////////////////////////////////////////////////
//                if (x is picturebox && (string)x.tag == "alien")
//                {
//                    if (player.bounds.intersectswith(x.bounds))
//                    {
//                        playerhealth -= 5;
//                    }
//                    if (x.left > player.left)
//                    {
//                        x.left -= alienspeed;
//                        ((picturebox)x).image = properties.resources.alien;
//                    }
//                    if (x.left < player.left)
//                    {
//                        x.left += alienspeed;
//                        ((picturebox)x).image = properties.resources.alien;
//                    }
//                    if (x.top > player.top)
//                    {
//                        x.top -= alienspeed;
//                        ((picturebox)x).image = properties.resources.alien;
//                    }
//                    if (x.top < player.top)
//                    {
//                        x.top += alienspeed;
//                        ((picturebox)x).image = properties.resources.alien;
//                    }
//                }
//                /////////////////////////////////////////////////


//                if (score % 10 == 0 && score != 0)
//                {
//                    makealien();
//                }


//                foreach (control j in this.controls)
//                {
//                    if (j is picturebox && (string)j.tag == "bullet" && x is picturebox && (string)x.tag == "zombie")
//                    {
//                        if (x.bounds.intersectswith(j.bounds))
//                        {
//                            score++;
//                            this.controls.remove(j);
//                            ((picturebox)x).dispose();
//                            zombieslist.remove(((picturebox)x));
//                            makezombies();
//                            //if (score % 10 == 0 && score != 0)
//                            //{
//                            //    makealien();  
//                            //}
//                        }
//                    }

//                }
//                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                foreach (control j in this.controls)
//                {
//                    if (j is picturebox && (string)j.tag == "bullet" && x is picturebox && (string)x.tag == "alien")
//                    {
//                        if (x.bounds.intersectswith(j.bounds))
//                        {
//                            alienhealth--;

//                            if (alienhealth == 0)
//                            {
//                                score += 5;
//                                this.controls.remove(j);
//                                ((picturebox)x).dispose();
//                                alienlist.remove(((picturebox)x));
//                                alienhealth = 3;

//                                // makealien();
//                            }

//                        }
//                    }
//                }
//                //if (this.controls is picturebox && (string)control == "bullet" && x is picturebox && (string)x.tag == "alien")
//                //{

//                //    alienhealth++;

//                //    if (alienhealth == 3)
//                //    {
//                //        score++;
//                //        this.controls.remove(j);
//                //        ((picturebox)x).dispose();
//                //        alienlist.remove(((picturebox)x));
//                //        alienhealth = 0;

//                //        // makealien();
//                //    }
//                //    ////////////////////////////////////////////////////////////////////


//            }


//        }

//        private void keyisdown(object sender, keyeventargs e)
//        {
//            if (gameover == true)
//            {
//                return;
//            }
//            if (e.keycode == keys.left)
//            {
//                goleft = true;
//                facing = "left";
//                player.image = properties.resources.left;
//            }
//            if (e.keycode == keys.right)
//            {
//                goright = true;
//                facing = "right";
//                player.image = properties.resources.right;
//            }
//            if (e.keycode == keys.up)
//            {
//                goup = true;
//                facing = "up";
//                player.image = properties.resources.up;
//            }
//            if (e.keycode == keys.down)
//            {
//                godown = true;
//                facing = "down";
//                player.image = properties.resources.down;
//            }



//        }

//        private void keyisup(object sender, keyeventargs e)
//        {
//            if (e.keycode == keys.left)
//            {
//                goleft = false;

//            }
//            if (e.keycode == keys.right)
//            {
//                goright = false;

//            }
//            if (e.keycode == keys.up)
//            {
//                goup = false;

//            }
//            if (e.keycode == keys.down)
//            {
//                godown = false;

//            }
//            if (e.keycode == keys.space && ammo > 0 && gameover == false)
//            {
//                ammo--;
//                shootebullet(facing);


//                if (ammo < 1)
//                {
//                    dropammo();
//                }
//            }
//            if (e.keycode == keys.enter && gameover == true)
//            {
//                restartgame();
//            }
//        }

//        private void label3_click(object sender, eventargs e)
//        {

//        }

//        private void shootebullet(string direction)
//        {
//            bullet shootbullet = new bullet();
//            shootbullet.direction = direction;
//            shootbullet.bulletsleft = player.left + (player.width / 2);
//            shootbullet.bulletstop = player.top + (player.height / 2);
//            shootbullet.makebullet(this);


//        }
//        private void makezombies()
//        {
//            picturebox zombie = new picturebox();
//            zombie.tag = "zombie";
//            zombie.image = properties.resources.zdown;
//            zombie.backcolor = color.transparent;
//            zombie.left = randnum.next(0, 900);
//            zombie.top = randnum.next(0, 800);
//            zombie.sizemode = pictureboxsizemode.autosize;

//            zombieslist.add(zombie);
//            this.controls.add(zombie);
//            player.bringtofront();
//        }
//        /// <summary>
//        /// //////////////////////////////////////////////////////////////////////////////////////////////////
//        /// </summary>
//        private void makealien()
//        {
//            picturebox alien = new picturebox();
//            alien.tag = "alien";
//            alien.image = properties.resources.alien;
//            alien.backcolor = color.transparent;
//            alien.left = randnum.next(0, 900);
//            alien.top = randnum.next(0, 800);
//            alien.sizemode = pictureboxsizemode.stretchimage;

//            alienlist.add(alien);
//            this.controls.add(alien);
//            player.bringtofront();
//            score++;
//        }
//        /// <summary>
//        /// /////////////////////////////////////////////////////////////////////////////////////////////////
//        /// </summary>
//        private void dropammo()
//        {
//            picturebox ammo = new picturebox();
//            ammo.image = properties.resources.ammo_image;
//            ammo.sizemode = pictureboxsizemode.autosize;
//            ammo.left = randnum.next(10, this.clientsize.width - ammo.width);
//            ammo.top = randnum.next(60, this.clientsize.width - ammo.height);
//            ammo.tag = "ammo";
//            this.controls.add(ammo);
//            ammo.bringtofront();
//            player.bringtofront();
//        }
//        private void restartgame()
//        {
//            player.image = properties.resources.up;
//            foreach (picturebox i in zombieslist)
//            {
//                this.controls.remove(i);
//            }
//            ///////////////////////////////////////////////////////////////////////////////////
//            foreach (picturebox i in alienlist)
//            {
//                this.controls.remove(i);
//            }
//            ////////////////////////////////////////////////////////////////////////////////////
//            alienlist.clear();
//            ///////////////////////////////////
//            zombieslist.clear();

//            for (int i = 0; i < 3; i++)
//            {
//                makezombies();
//            }

//            //////////////////////////////////////////////////////
//            //for (int j = 0; j < 1; j++)
//            //{
//            //   if (score%10==0)
//            //    {
//            //    makealien();
//            //    }
//            //}
//            ///////////////////////////////////////////////////////////

//            godown = false;
//            goleft = false;
//            goright = false;
//            goup = false;
//            gameover = false;

//            playerhealth = 100;
//            score = 0;
//            ammo = 10;

//            gametimer.start();

//        }
//    }
//}







