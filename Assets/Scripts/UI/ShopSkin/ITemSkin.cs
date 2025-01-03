
using Assets.Scripts.Event;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.ShopSkin
{
    public class ITemSkin : MonoBehaviour
    {
        [SerializeField] private GameObject lockImage;

        private DataSkin data;
        private DataSkinPant dataPants;
       


        public void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(() => SetEventButton());
        }
        public void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
        }

        private void SetEventButton()
        {
           if (dataPants != null)
           {
                ChangeClotheEvent.changePants?.Invoke(dataPants);
           }
           else
           {
                ChangeClotheEvent.changeClothes(data.ID);
           }

        }

        public void SetData(DataSkin data)
        {
            this.data = data;
            UpdateUI(data.Image);
        }
        public void SetDataPants(DataSkinPant dataPants)
        {
            this.dataPants = dataPants;
            UpdateUI(dataPants.Image);
           
        }


        public void UpdateUI(Sprite image)
        {

            GetComponent<Image>().sprite = image;
            if(data != null && !data.wasBought)
            {
                lockImage.SetActive(true);
            }
            if (dataPants != null && !dataPants.wasBought)
            {
                lockImage.SetActive(true);
            }
        }

    }
}
