
using NUnit.Framework;
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.UI.ShopSkin
{
    public class DisplayItemSkin : MonoBehaviour
    {
        [SerializeField] private GameObject Item;
        private List<DataSkin> listItem;
        private List<DataSkinPant> listPants;

        private List<GameObject> buttons = new List<GameObject>();

        private bool isPants= false;


       

        public void DisplayITem()
        {
           
            if(buttons.Count > 0)
            {
                foreach (GameObject button in buttons)
                {

                    Destroy(button);
                }
            }
          
            buttons.Clear();
            if (!isPants)
            {
                foreach (DataSkin skin in listItem)
                {

                    GameObject game = Instantiate(Item, this.transform);
                    game.GetComponent<ITemSkin>().SetData(skin);
                    buttons.Add(game);
                }
            }
            else
            {
                foreach (DataSkinPant skin in listPants)
                {

                    GameObject game = Instantiate(Item, this.transform);
                    game.GetComponent<ITemSkin>().SetDataPants(skin);
                    buttons.Add(game);
                }
            }
            

        }

        public void SetDataPants(List<DataSkinPant> listSkin)
        {
            this.listPants = listSkin;
            isPants = true;
            DisplayITem();
            

        }

        public void SetData(List<DataSkin> list)
        {
            this.listItem = list;
            isPants = false;
            DisplayITem();
            

        }
    }
}
