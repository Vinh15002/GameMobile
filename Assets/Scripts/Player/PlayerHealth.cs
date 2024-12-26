using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Health
{
    public class PlayerHealth : ObjectHealth
    {
        private void FixedUpdate()
        {
            if (IsDead())
            {
                Destroy(gameObject);
            }
        }

    }
}
