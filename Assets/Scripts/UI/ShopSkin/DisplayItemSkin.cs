
using Assets.Scripts.Event;
using Assets.Scripts.UI.Gold;

using System;
using System.Collections.Generic;
using Assets.Scripts.UI.ShopSkin;
using UnityEngine;
using UnityEngine.UI;
using UnityEditorInternal.VersionControl;
using Assets.Scripts.ScripTableObject.Skin;
using System.Data;
using Unity.VisualScripting;



public class DisplayItemSkin: MonoBehaviour
{
    [SerializeField] private GameObject ItemObject;
    [SerializeField] private GameObject ItemClothe;
    [SerializeField] private GameObject ItemFullSkin;


    private List<DataSkin> listAll = new List<DataSkin>();
    private List<GameObject> buttons = new List<GameObject>();
    private int typeSkin = 0;

        

    private int positionSelected;

    [SerializeField] private GameObject buttonSelect;
    [SerializeField] private GameObject buttonBuy;

    private void OnEnable()
    {
        ChooseButtonEvent.changeOutLine += ChangeOutLine;
        
            
    }
    private void OnDisable()
    {
        ChooseButtonEvent.changeOutLine -= ChangeOutLine;
    }


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

        int count = 0;
        foreach (var skin in listAll)
        {
            GameObject item = null;
            if(typeSkin == 0)
            {
                item = Instantiate(ItemObject, this.transform);
                item.GetComponent<ITemSkin>().SetData(skin, count);
            }
            else if(typeSkin == 1)
            {
                item = Instantiate(ItemClothe, this.transform);
                item.GetComponent<ITemSkin>().SetData((DataSkinPant)skin, count);
            }
            else if(typeSkin == 2)
            {
                item = Instantiate(ItemFullSkin, this.transform);
                item.GetComponent<ITemSkin>().SetData((DataFullSkin)skin, count);
            }
            
            buttons.Add(item);
            count++;
        }
        

        
            

    }


    private void ChangeOutLine(int index)
    {
        positionSelected = index;
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Button>().GetComponent<Outline>().enabled = false;
        }
        buttons[index].GetComponent<Outline>().enabled = true;
        setDisplayButton();

    }


    public void setDisplayButton()
    {
        bool check = true;
        int gold = 0;
        
        check = buttons[positionSelected].GetComponent<ITemSkin>().wasBought();
        gold = buttons[positionSelected].GetComponent<ITemSkin>().getGold();
        
       


        if (check)
        {
            //buttonSelect.SetActive(true);
            buttonBuy.SetActive(false);
         

        }
        else
        {
                
            buttonBuy.SetActive(true);
            buttonBuy.GetComponent<BuyClothe>().setGold(gold);
            //buttonSelect.SetActive(false);
        }
    }

    public void SetDataObject(List<DataSkin> dataListItem)
    {
        typeSkin = 0;
        listAll.Clear();
        foreach (DataSkin skin in dataListItem)
        {
            listAll.Add(skin);
        }

        DisplayITem();
    }


    public void SetDataClothe(List<DataSkinPant> dataListItem)
    {
        typeSkin = 1;
        listAll.Clear();
        foreach (DataSkinPant skin in dataListItem)
        {
            listAll.Add(skin);
        }
        DisplayITem();
    }

    public void SetDataFullSkin(List<DataFullSkin> fullSkins)
    {

        typeSkin = 2;
        listAll.Clear();
        foreach (DataFullSkin skin in fullSkins)
        {
            listAll.Add(skin);
        }
        DisplayITem();
    }
      

    public void BuySkin()
    {
        buttons[positionSelected].GetComponent<ITemSkin>().BuyItem();
        setDisplayButton();
    }

    
}
