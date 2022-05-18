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
    class Alien : Monster
    {
        private static Random rand = new Random();
        List<PictureBox> alienList = new List<PictureBox>();

        public Alien() : base()
        {
            this._speed = 2;
            this._health = 3;
            this._livingName = "Alien";
            this._livingType = 4;
            this._imageName = "Alien";
            this._damageNumber = 10;
            //this.goUp = false;
            //this.goRight = false;
            //this.goLeft = false;
            //this.goDown = false;

        }
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
        public PictureBox create_alien_PictureBox()
        {
            PictureBox alien = new PictureBox();
            alien.Tag = "alien";
            alien.Image = Properties.Resources.zdown;
            alien.BackColor = Color.Transparent;
            alien.Left = rand.Next(0, 900);
            alien.Top = rand.Next(0, 800);
            alien.SizeMode = PictureBoxSizeMode.AutoSize;
            alienList.Add(alien);
            return alien;
        }
        public void set_health(int x)
        {
            _health = x;
        }
        public void set_damage_to_health(int x)
        {
            _health -= x;
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
