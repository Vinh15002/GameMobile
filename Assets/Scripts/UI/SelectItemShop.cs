using Assets.Scripts.Event;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Gold;
using Assets.Scripts.UI.SelectWeapon;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class SelectItemShop : MonoBehaviour
{

    [SerializeField] private TMP_Text itemName;

    [SerializeField] private List<GameObject> listItem;
    [SerializeField] private List<GameObject> listCustomSkin;

    [SerializeField] private List<DataWeapon> dataSkin;

    [SerializeField] private GameObject skinShop;

    [SerializeField] private GameObject buttonBuy;

    [SerializeField] private GameObject buttonSelect;


    [SerializeField] private GameObject Player;
   


    private int currentItem = 0;

    private int currentItemEquipped = 0;


    public static SelectItemShop Instance;


    private void OnEnable()
    {
        Instance = this;
        setUIItem(currentItem);
        setUpSkin(currentItem);

        ChangeSkinEvent.changeSkin += ChangeSkinWeapon;
        ChangeSkinEvent.changeSkinCustome += ChangSkinCustome;
        //ShopSkinWeapon.Instance.SetActiveCustomeSkin(false);
        SetDisplayCustomeSkin();
    }

    private void SetDisplayCustomeSkin()
    {
        ChangSkinCustome(dataSkin[currentItem].skins[0].materials);
    }

    private void ChangSkinCustome(Material[] materials)
    {
       
        listCustomSkin[currentItem].GetComponent<MeshRenderer>().materials = materials;
    }

    private void ChangeSkinWeapon(Material[] materials)
    {
        listItem[currentItem].GetComponent<MeshRenderer>().materials = materials;
    }

    public void OnLeftClick()
    {
        currentItem = currentItem == 0 ? listItem.Count-1 : currentItem - 1;
        setUIItem(currentItem);
        setUpSkin(currentItem);

    }

    public void OnRightClick()
    {
        currentItem = currentItem == listItem.Count-1 ? 0 : currentItem+1;
        setUIItem(currentItem);
        setUpSkin(currentItem);
    }

    private void setUIItem(int position)
    {

       

        foreach (var item in listItem)
        {
            item.gameObject.SetActive(false);
        }
        foreach(var item in listCustomSkin)
        {
            item.gameObject.SetActive(false);
        }
        itemName.text = listItem[position].gameObject.name;
        listItem[position].gameObject.SetActive(true);
        listCustomSkin[position].gameObject.SetActive(true);
      
        SetDisplayCustomeSkin();
        SetButtonSelect();
    }



    private void setUpSkin(int position)
    {
        if (!dataSkin[position].wasBought)
        {
           
            skinShop.SetActive(false);
            buttonBuy.SetActive(true);
            buttonSelect.SetActive(false);
            BuyItem.Instance.setGold(dataSkin[currentItem].gold);
        }
        else
        {
            buttonBuy.SetActive(false);
            skinShop.SetActive(true);
            buttonSelect.SetActive(true);
            skinShop.GetComponent<ShopSkinWeapon>().UpdateSkin(dataSkin[position].skins);
            skinShop.GetComponent<ShopSkinWeapon>().SetSelectedItem(2);
        }
        
    }

    public void BoughtItem()
    {
        dataSkin[currentItem].wasBought = true;
        setUpSkin(currentItem);

    }

    public void SetButtonSelect()
    {
        
     

        if(currentItemEquipped != currentItem)
        {
            buttonSelect.GetComponent<SelectButton>().SetSelect();
        }
        else
        {
            buttonSelect.GetComponent<SelectButton>().SetEquipped();
        }
    }

    public void SetItemEquipped()
    {
        currentItemEquipped = currentItem;
       
    }

 
    




}
