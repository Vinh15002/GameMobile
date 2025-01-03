using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Pooling
{
    public class WeaponPooling: MonoBehaviour
    {

        public static WeaponPooling Instance;


        

        private void Awake()
        {
            Instance = this;
        }

        public GameObject SpawnWeapon(int id)
        {
            GameObject game = transform.GetChild(id).GetComponent<ObjectPooling>().GetObject();
            return game;
        }
    }
}
