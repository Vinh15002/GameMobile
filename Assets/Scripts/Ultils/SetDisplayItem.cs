using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ultils
{
    public class SetDisplayItem : MonoBehaviour
    {




        public void ResetDisplay()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        public void SetActive(int id)
        {
            ResetDisplay();
            int amount = transform.childCount;

            if (id >= 0 && id < amount)
            {
                ResetDisplay();
                transform.GetChild(id).gameObject.SetActive(true);
            }


        }
    }
}   
