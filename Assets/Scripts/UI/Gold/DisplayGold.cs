using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Gold
{
    public class DisplayGold : MonoBehaviour
    {

        public static DisplayGold Instance;
        public int totalGold = 10000;

        [SerializeField] private TMP_Text text;


        public void Start()
        {
            Instance = this;
            totalGold = PlayerPrefs.GetInt("Gold", 1000);
            text.text = totalGold.ToString();
        }





        public void BuyItem(int amount)
        {
            totalGold -= amount;
            text.text = totalGold.ToString();
            PlayerPrefs.SetInt("Gold", totalGold);
            PlayerPrefs.Save();
        }
       
    }
}
