
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Gold
{
    public class Buy : MonoBehaviour
    {
        [SerializeField] protected Button buttonBuyGold;
        [SerializeField] protected TMP_Text goldDisplay;
        [HideInInspector] public int goldToBuy;




        public void setGold(int gold)
        {
            goldToBuy = gold;
            goldDisplay.text = goldToBuy.ToString();
        }

    }
}
