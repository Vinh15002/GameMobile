using Assets.Scripts.Event;

using UnityEngine.UI;

namespace Assets.Scripts.UI.ShopSkin
{
    public class ItemObject : ITemSkin
    {
        protected override void SendDataEvent()
        {
            GetComponent<Image>().sprite = data.Image;
            ChangeClotheEvent.changeClothes(data.ID, wasBought());
        }

     

        public override void BuyItem()
        {
            this.data.BuyItem();
            ChangeClotheEvent.changeClothes(data.ID, wasBought());
            this.lockImage.SetActive(false);
        }
    }
}
