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
   
    class Monster:Living
    {
        public int _addingScore;

       
        public Monster()
        {

            this._livingType = 1;

            this._speed = 1;
            this._health = 0;
            this._livingName = null;
            this._imageName = null;
            this._damageNumber = 0;
            this._addingScore = 0;
        }
        public int get_speed()
        {
            return _speed;
        }
        public int get_health()
        {
            return _health;
        }

        public void getDamege()
        {
            

        }
        public void makeNoise ()
        {
            
        }
        public void movement()
        {

        }

        //private static Random rand = new Random();
        //protected int _damegeNumber;
        //public Monster() : base()
        //{

        //}
    }
}
