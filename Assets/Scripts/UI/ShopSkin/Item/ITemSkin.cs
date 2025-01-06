
using Assets.Scripts.Event;
using System;
using Unity.Android.Gradle.Manifest;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.ShopSkin
{
    public abstract class ITemSkin : MonoBehaviour
    {
        public GameObject lockImage;
        [HideInInspector] public int Index;
        protected DataSkin data;

        //private DataSkin temp;
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
            ChooseButtonEvent.changeOutLine?.Invoke(Index);
            SendDataEvent();

        }
        public void SetData(DataSkin data, int count)
        {
            this.data = data;
            
            this.Index = count;
            UpdateUI();
        }
        public void UpdateUI()
        {
            SetLockItem();
        }
        protected abstract void SendDataEvent();
        protected  void SetLockItem()
        {
            GetComponent<Image>().sprite = data.Image;
            if (wasBought())
            {
                this.lockImage.SetActive(false);
            }
            else this.lockImage.SetActive(true);
        }

        public  bool wasBought()
        {
            return data.wasBought;
        }
        public  int getGold()
        {
            return data.price;
        }

        public abstract void BuyItem();
        

       
    }
}
