
using Assets.Scripts.Event;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



namespace Assets.Scripts.UI.Skin
{
    public class ChangeMaterialColor: MonoBehaviour
    {
        public List<GameObject> amountMaterial;

        public DataSkinWeapon weapon;


        public int currentIndexMaterial= -1;

        public static ChangeMaterialColor Instance;



        public void OnEnable()
        {
            Instance = this;

            ChangeSkinEvent.changeColor += ChangeColor;



        }



        private void ChangeColor(Color color)
        {

            
            if (currentIndexMaterial == -1) return;
            amountMaterial[currentIndexMaterial].GetComponent<ButtonMaterial>().button.image.color = color;
            weapon.materials[currentIndexMaterial].color = color;

            ChangeSkinEvent.changeSkin?.Invoke(weapon.materials);
            ChangeSkinEvent.changeSkinCustome?.Invoke(weapon.materials);

        }

        public void OnDisable()
        {
            
        }

        public void SetUpMaterial()
        {
            
            int index = 0;
           
            foreach(GameObject item in amountMaterial)
            {
                if(index < weapon.materials.Length)
                {
                    item.SetActive(true);
                    item.GetComponent<ButtonMaterial>().button.image.color = weapon.materials[index].color;
                }
                else item.SetActive(false);
                index++;
            }
        }

        public void setData(DataSkinWeapon data)
        {
            this.weapon = data;
            SetUpMaterial();
        }
    }
}
