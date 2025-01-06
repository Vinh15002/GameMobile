
using Assets.Scripts.Event;
using Assets.Scripts.UI.Skin;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Assets.Scripts.UI
{
    public class ShopSkinWeapon : MonoBehaviour
    {

        [SerializeField] private List<GameObject> ItemUI;


        [SerializeField] private GameObject CustomeSkin;




        public static ShopSkinWeapon Instance;
     


        public void OnEnable()
        {
            Instance = this;
            CustomeSkin.SetActive(false);
            ChangeSkinEvent.changeSelected += SetSelectedItem;
            ChangeSkinEvent.displayCustomeSkin += displaySkinCustome;
            

       
            
        }

        public void OnDisable()
        {
            ChangeSkinEvent.changeSelected -= SetSelectedItem;
            ChangeSkinEvent.displayCustomeSkin -= displaySkinCustome;
            CustomeSkin.SetActive(false);
        }
        private void displaySkinCustome(DataSkinWeapon data)
        {
            CustomeSkin.GetComponentInChildren<ChangeMaterialColor>().setData(data);
        }

       


        public void UpdateSkin(List<DataSkinWeapon> list)
        {

           
            int index = 0;
            for(int i = 0 ; i < ItemUI.Count; i++) {
                if (index < list.Count)
                {
                    ItemUI[i].SetActive(true);
                    ItemUI[i].GetComponent<ChooseSkin>().SetData(list[index]);
                    index++;
                }
                else
                {
                    ItemUI[i].SetActive(false);
                }
            }
           
        }


        public void SetSelectedItem(int index)
        {
            if (index == 0) CustomeSkin.SetActive(true);
            else
            {
                CustomeSkin.SetActive(false);
            }

            foreach (var item in ItemUI)
            {
                item.GetComponent<ChooseSkin>().Selected.SetActive(false);
            }
            ItemUI[index].GetComponent<ChooseSkin>().Selected.SetActive(true);
        }


       
    }
}
