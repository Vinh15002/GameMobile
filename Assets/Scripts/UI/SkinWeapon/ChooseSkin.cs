using Assets.Scripts.Event;
using Assets.Scripts.UI.Skin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ChooseSkin : MonoBehaviour
    {

        public DataSkinWeapon data;
        public Button button;
        public GameObject Selected;
      




       

        public void OnClickButton()
        {
            
            
            if (data.ID != 0)
            {
                Selected.SetActive(true);

                ChangeSkinEvent.changeSkin?.Invoke(data.materials);
                

            }
            else
            {
                ChangeSkinEvent.displayCustomeSkin?.Invoke(data);
                ChangeSkinEvent.changeSkin?.Invoke(data.materials);
               
            }
            ChangeSkinEvent.changeSelected?.Invoke(data.ID);


        }

        public void SetData(DataSkinWeapon data)
        {
            this.data = data;
           
            if(data.ID != 0)
            {
                button.GetComponent<Image>().sprite = data.image;
            }
            Selected.SetActive(false);
        }


    }
}
