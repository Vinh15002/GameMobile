using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Event
{
    public static  class FindEnemyEvent
    {



        public delegate void FindEnemy(Vector3 position);

        public static FindEnemy findEnemy;
    }
}
