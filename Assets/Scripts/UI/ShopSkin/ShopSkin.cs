
using Assets.Scripts.Event;
using Assets.Scripts.Player;
using Assets.Scripts.UI.ShopSkin;
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Event.ChangeClotheEvent;

public class ShopSkin : MonoBehaviour
{

    [SerializeField] private List<DataSkin> Hats;
    [SerializeField] private List<DataSkinPant> Pants;
    [SerializeField] private List<DataSkin> Shields;


    [SerializeField] private GameObject displayItem;
    [SerializeField] private List<Button> buttonSelectType;
    


    public int positionSelected = 0;



    private void OnEnable()
    {
        
       
        DisplayData();
        SetEventForAllButton();
        ChangeClotheEvent.changePants += ChangePant;
        ChangeClotheEvent.changeClothes += ChangeClothe;
        Player.instance.SetDanceEnabled();

    }

   
    private void OnDisable()
    {
        ChangeClotheEvent.changePants -= ChangePant;
        ChangeClotheEvent.changeClothes -= ChangeClothe;
        Player.instance.SetDanceDisaabled();
        
    }


    private void DisplayData()
    {
     
         SetDisplayItem(Hats);
        
    }

   

    private void SetEventForAllButton()
    {
        
        for(int i = 0; i < buttonSelectType.Count; i++)
        {
            if(i== 0)
            {
                buttonSelectType[i].onClick.AddListener(() => ButtonEvent(Hats, 0));
            }
            else if (i == 1) buttonSelectType[i].onClick.AddListener(() => ButtonEventPants(Pants, 1));
            else if (i == 2) buttonSelectType[i].onClick.AddListener(() => ButtonEvent(Shields, 2));

        }
    }


    public void ButtonEvent(List<DataSkin> listSkin, int indexdSelected)
    {
        SetDisplayItem(listSkin);
        
        positionSelected = indexdSelected;
    }

    public void ButtonEventPants(List<DataSkinPant> listSkin, int indexdSelected)
    {
        SetDisplayItemPants(listSkin);
        positionSelected = indexdSelected;
    }

    private void SetDisplayItemPants(List<DataSkinPant> listSkin)
    {
        displayItem.GetComponent<DisplayItemSkin>().SetDataPants(listSkin);
    }

    private void SetDisplayItem(List<DataSkin> listSkin)
    {
        
        displayItem.GetComponent<DisplayItemSkin>().SetData(listSkin);
       
    }

    private void ChangePant(DataSkinPant data)
    {
        if(positionSelected == 1)
        {
            Player.instance.ChangePants(data);
        }
        
    }
    private void ChangeClothe(int id)
    {
       if(positionSelected == 0)
       {
            Player.instance.ChangeHat(id);
       }

       else if (positionSelected == 2)
       {
            Player.instance.ChangeShield(id);
        }
    }
    




}

