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
    
    class Living
    {
        public bool goLeft, goRight, goUp, goDown, gameOver;

        protected int _livingType;

        protected string _livingName;
        protected int _health;
        protected int _speed;
        protected int _damageNumber;
        protected string _imageName;
        public Living()
        {
            this._livingType = 0;

            this._speed = 1;
            this._health = 0;
            this._livingName = null;
            this._imageName = null;
            this._damageNumber = 0;
        }
        public int get_speed()
        {
            return _speed;
        }
        public int get_health()
        {
            return _health;
        }
        public void movement()
        {

        }
        public void makeNoise()
        {

        }

        //private SoundPlayer audio = new SoundPlayer();
        //private static Random rand = new Random();
        //protected int _speed;
        //public int _health;
        //protected string _imageName;
        //protected int _score;
        //protected  int _coordinates_Left, _coordinates_Top;
     
       

        //protected virtual void makeNoise() { }
        //public virtual void displayLiving(PictureBox visual) { }
        


    }
}
