
using System;
using UnityEngine;


namespace Assets.Scripts.UI.Gold
{
    public class BuyClothe : Buy
    {
        [HideInInspector]public BuyClothe Instance;

     

        public void OnEnable()
        {
            Instance = this;
            buttonBuyGold.onClick.AddListener(() =>
            {
                BuySkin();

            });
        }

        private void BuySkin()
        {
            if (goldToBuy <= DisplayGold.Instance.totalGold)
            {
                DisplayGold.Instance.BuyItem(goldToBuy);
                ShopClothe.Instance.BuySkin();
                this.gameObject.SetActive(false);



            }
        }
    }
}
