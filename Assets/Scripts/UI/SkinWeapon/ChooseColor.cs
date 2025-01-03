
using Assets.Scripts.Event;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChooseColor : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;

    private void OnEnable()
    {
        AddEventButton();
    }



    void AddEventButton()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnClickButton(button));
        }
    }

    private void OnClickButton(Button button)
    {
        
        ChangeSkinEvent.changeColor?.Invoke(button.GetComponent<Image>().color);
    }
}
