using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Skin
{
    public class ButtonMaterial : MonoBehaviour
    {
        
        public Button button;

        public int indexSkin;


        public void Start()
        {
            SetClickEvent();
        }

        private void SetClickEvent()
        {
            button.onClick.AddListener(() => {
                ChangeMaterialColor.Instance.currentIndexMaterial = indexSkin;
            
            }
            
            
            );
           
        }
    }
}
