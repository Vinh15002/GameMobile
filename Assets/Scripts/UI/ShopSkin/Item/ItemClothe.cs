using Assets.Scripts.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.ShopSkin
{
    public class ItemClothe : ITemSkin
    {
        

        protected override void SendDataEvent()
        {
            GetComponent<Image>().sprite = data.Image;
            ChangeClotheEvent.changePants?.Invoke((DataSkinPant)this.data,this.data.wasBought);
        }

  
        public override void BuyItem()
        {
            this.data.BuyItem();
            ChangeClotheEvent.changePants?.Invoke((DataSkinPant)this.data, this.data.wasBought);
            this.lockImage.SetActive(false);
        }
        
    }
}
