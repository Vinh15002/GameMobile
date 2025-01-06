using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.SelectWeapon
{
    public  class SelectButton : MonoBehaviour
    {
        [SerializeField] private Button buttonSelect;
        [SerializeField] private Button buttonEquipped;

        public static SelectButton Instance;

        private void Awake()
        {
            Instance = this;
            buttonSelect.onClick.AddListener(() => setEventSelect());;
            buttonEquipped.onClick.AddListener(() => setEventSelect());


        }

        public void SetSelect()
        {
            buttonSelect.gameObject.SetActive(true);
            buttonEquipped.gameObject.SetActive(false);
        }

        public void SetEquipped()
        {
            buttonSelect.gameObject.SetActive(false);
            buttonEquipped.gameObject.SetActive(true);
        }

        public void setEventSelect()
        {
            SelectItemShop.Instance.SetItemEquipped();
           
           

        }

      



    }
}
