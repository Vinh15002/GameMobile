using Assets.Scripts.Event;
using Assets.Scripts.ScripTableObject.Skin;
using System;

using UnityEngine.UI;

namespace Assets.Scripts.UI.ShopSkin.Item
{
    public class ItemFullSkin : ITemSkin
    {
        public override void BuyItem()
        {
            this.data.BuyItem();
            ChangeClotheEvent.changeFullSkinEvent?.Invoke((DataFullSkin)this.data, this.data.wasBought);
            this.lockImage.SetActive(false);
        }

       


        protected override void SendDataEvent()
        {
            GetComponent<Image>().sprite = data.Image;
            ChangeClotheEvent.changeFullSkinEvent?.Invoke((DataFullSkin)this.data, this.data.wasBought);
        }


    }
}
