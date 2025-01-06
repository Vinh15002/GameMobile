using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    [CreateAssetMenu(fileName = "DataObject", menuName = "Game/DataObject")]
    public class ObjectDataSO : ScriptableObject
    {
        public Material bodyMaterial;
        public Material pansMaterial;


        public Mesh meshWeapon;
        public Material[] materials;
        
        public int level;


        public int typeWeapon;

        public Color mainCoLor;


        public string name;

        public int idHat;

        public int idShield;

        public int idBack = -1;


    }
}
