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

    class Soldier:Living
    {
        

        public string facing = "up";
        private static Random rand = new Random();

        public Soldier()
        { 
            this._speed = 10;
            this._health = 100;
            this._livingName = "soldier";
            this._livingType = 2;
            this._imageName = "up";
            this._damageNumber = 1;
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
        public void set_new_health(int x)
        {
            _health = x;
        }
        public void set_gameOver(bool x)
        {
            gameOver = x;
        }
        public bool get_gameOver()
        {
            return gameOver;
        }
        public int get_damage()
        {
            return _damageNumber;
        }
        public int get_speed()
        {
            return _speed;
        }
        public void set_speed(int x)
        {
            _speed += x;
            
        }
        public void set_health(int x)
        {
            _health -= x;
        }
        public int get_health()
        {
            return _health;
        }
        public PictureBox create_soldier_PictureBox()
        {
            PictureBox soldier = new PictureBox();
            soldier.Tag = "player";
            soldier.Image = Properties.Resources.up;
            soldier.BackColor = Color.Transparent;
            soldier.Left = rand.Next(0, 900);
            soldier.Top = rand.Next(0, 800);
            soldier.SizeMode = PictureBoxSizeMode.AutoSize;
            return  soldier;
        }
        public bool live_or_dead()
        {
            if (this._health > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       public void do_damege()
        {

        }


    }
    
}
