
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Gold
{
    public class BuyItem : Buy
    {
        public static BuyItem Instance;





       
        public void OnEnable()
        {
            Instance = this;
            AddEventClickBuyItem();
        }

        private void AddEventClickBuyItem()
        {
            buttonBuyGold.onClick.AddListener(() =>
            {
                if( goldToBuy <= DisplayGold.Instance.totalGold) {
                    DisplayGold.Instance.BuyItem(goldToBuy);
                    SelectItemShop.Instance.BoughtItem();
                
                }

            });
        }

        
    }
}
