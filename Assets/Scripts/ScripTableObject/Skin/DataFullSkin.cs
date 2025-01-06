using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScripTableObject.Skin
{


    [CreateAssetMenu(fileName = "Data", menuName = "Data/DataSkin/FullSkin")]
    public class DataFullSkin : DataSkin
    {
        public Material[] body;
        public Material[] pant;
        public int IdHat;
        public int IdBack;
        public int IdShield = -1;


    }
}
