using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Event
{
    public  class SetLevelEvent
    {
        public delegate void SetPositonUI(float scale);
        public static SetPositonUI setPositonUI;

        public delegate void SetUIScore(int score);
        public static SetUIScore setUIScore;

    }
}
