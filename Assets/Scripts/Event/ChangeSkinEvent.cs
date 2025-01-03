using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Event
{
    public class ChangeSkinEvent
    {
        public delegate void ChangeSkin(Material[]  materials);

        public static ChangeSkin changeSkin;


        public delegate void ChangeSelected(int index);

        public static ChangeSelected changeSelected;



        public delegate void ChangeColor(Color color);
        public static ChangeColor changeColor;


        public delegate void ChangeSkinCustome(Material[] materials);

        public static ChangeSkinCustome changeSkinCustome;



        public delegate void DisplayCustomeSkin(DataSkinWeapon data);

        public static DisplayCustomeSkin displayCustomeSkin;
    }
}
