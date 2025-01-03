using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "DataObject", menuName = "Game/DataObject")]
    public class ObjectData : ScriptableObject
    {
        public Material bodyMaterial;
        public Material pansMaterial;


        public GameObject weapon;
        
        public int level;


        public int typeWeapon;

        public Color mainCoLor;


        public string name;

    }
}
