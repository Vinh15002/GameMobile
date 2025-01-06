
using Assets.Scripts.Event;
using Assets.Scripts.Player;
using Assets.Scripts.ScripTableObject.Skin;
using Assets.Scripts.UI.ShopSkin;
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class ShopClothe : MonoBehaviour
{

    [SerializeField] private List<DataSkin> Hats;
    [SerializeField] private List<DataSkinPant> Pants;
    [SerializeField] private List<DataSkin> Shields;
    [SerializeField] private List<DataFullSkin> FullSkins;


    [SerializeField] private GameObject displayItem;
    [SerializeField] private List<Button> buttonSelectType;


    [SerializeField] private GameObject Shop;

    [HideInInspector]public static ShopClothe Instance;

    [HideInInspector]public int positionSelected = 0;






    private void OnEnable()
    {

        Instance = this;


        DisplayData();
        SetEventForAllButton();
        ChangeClotheEvent.changePants += ChangePant;
        ChangeClotheEvent.changeClothes += ChangeClothe;
        ChangeClotheEvent.changeFullSkinEvent += ChangeFullSkin;
        Player.instance.SetDanceEnabled();

    }

   

    private void OnDisable()
    {
        ChangeClotheEvent.changePants -= ChangePant;
        ChangeClotheEvent.changeClothes -= ChangeClothe;
        ChangeClotheEvent.changeFullSkinEvent -= ChangeFullSkin;
        Player.instance.SetDanceDisaabled();

    }


    private void DisplayData()
    {

        SetDisplayItemPants(Pants);
        
    }

   

    private void SetEventForAllButton()
    {
        
        for(int i = 0; i < buttonSelectType.Count; i++)
        {
            if (i == 0) buttonSelectType[i].onClick.AddListener(() => ButtonEvent(Hats, 0));
            else if (i == 1) buttonSelectType[i].onClick.AddListener(() => ButtonEventPants(Pants, 1));
            else if (i == 2) buttonSelectType[i].onClick.AddListener(() => ButtonEvent(Shields, 2));
            else if (i == 3) buttonSelectType[i].onClick.AddListener(() => ButtonEventFullSkin(FullSkins, 3));

        }
    }

    public void ButtonEventFullSkin(List<DataFullSkin> fullSkins, int indexSelected)
    {
        SetDisPlayItemSkinFull(fullSkins);
        positionSelected = indexSelected;
    }

    public void SetDisPlayItemSkinFull(List<DataFullSkin> fullSkins)
    {
        displayItem.GetComponent<DisplayItemSkin>().SetDataFullSkin(fullSkins);
    }

    public void ButtonEvent(List<DataSkin> listSkin, int indexdSelected)
    {
        positionSelected = indexdSelected;
        SetDisplayItem(listSkin);
        
        
    }

    public void ButtonEventPants(List<DataSkinPant> listSkin, int indexdSelected)
    {
        positionSelected = indexdSelected;
        SetDisplayItemPants(listSkin);
        
    }

    private void SetDisplayItemPants(List<DataSkinPant> listSkin)
    {
        displayItem.GetComponent<DisplayItemSkin>().SetDataClothe(listSkin);
    }

    private void SetDisplayItem(List<DataSkin> listSkin)
    {
        
        displayItem.GetComponent<DisplayItemSkin>().SetDataObject(listSkin);
       
    }

    public void ChangePant(DataSkinPant data, bool value)
    {
      
        Player.instance.ChangePants(data, value);
      
        
    }
    public void ChangeClothe(int id, bool value)
    {
       if(positionSelected == 0)
       {
            Player.instance.ChangeHat(id, value);
       }

       else if (positionSelected == 2)
       {
            Player.instance.ChangeShield(id, value);
       }
    }
    private void ChangeFullSkin(DataFullSkin data, bool value)
    {
        Player.instance.ChangeFullSkin(data, value);
    }

    public void BuySkin()
    {
        displayItem.GetComponent<DisplayItemSkin>().BuySkin();
        //if (positionSelected == 0 || positionSelected == 2)
        //{
            
        //}
        //else if (positionSelected == 1)
        //{
        //    displayItem.GetComponent<DisplayItemSkin>().BuySkin();
        //}
        //else if(positionSelected == 3)
        //{
        //    displayItem.GetComponent<DisplayItemSkin>().BuySkin();
        //}
    }
        
    
    
    public void SetDisActive()
    {
        Player.instance.SetData();
    }




}

