
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Gold
{
    public class BuyItem : MonoBehaviour
    {
        public static BuyItem Instance;



        [SerializeField] private Button buttonBuyGold;
        [SerializeField] private TMP_Text goldDisplay;

        public int goldToBuy;

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

        public void setGold(int gold)
        {
            goldToBuy = gold;
            goldDisplay.text = goldToBuy.ToString();
        }
    }
}
