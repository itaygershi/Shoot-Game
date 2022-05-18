//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Shoot_Game
{
    class Zombie:Monster
    {
        global::Shoot_Game.Form1.
        private static Random rand = new Random();
       

        string x = "\n alien constractor.";
        // List<PictureBox> zombiesList = new List<PictureBox>();
        public Zombie()
        {
            this._speed = 1;
            this._health = 1;
            this._livingName = "zombie";
            this._livingType = 3;
            this._imageName = "zup";
            this._damageNumber = 1;
            //this.goUp = false;
            //this.goRight = false;
            //this.goLeft = false;
            //this.goDown = false;

            print_to_text_box(x);
    }
        //public PictureBox create_zombie_PictureBox()
        //{
        //    PictureBox zombie = new PictureBox();
        //    zombie.Tag = "zombie";
        //    zombie.Image = Properties.Resources.zdown;
        //    zombie.BackColor = Color.Transparent;
            
        //    zombie.SizeMode = PictureBoxSizeMode.AutoSize;
        //    return zombie;
        //}
        public void set_goLeft(bool x)
        {
            this.goLeft = x;
        }
        public void set_goDown(bool x)
        {
            this.goDown = x;
        }
        public void set_goRight(bool x)
        {
            this.goRight = x;
        }
        public void set_goUp(bool x)
        {
            this.goUp = x;
        }
        public int get_damage()
        {
            return _damageNumber;
        }
        public int get_speed()
        {
            return _speed;
        }
        public int get_health()
        {
            return _health;
        }

    }
}
