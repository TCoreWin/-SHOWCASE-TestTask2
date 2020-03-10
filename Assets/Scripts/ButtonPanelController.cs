using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanelController : MonoBehaviour
{
    [SerializeField] int coutStartButtons = 5;

    Stack<GameObject> buttons = new Stack<GameObject>();

    private void Start()
    {
        for (int i = 0; i < coutStartButtons; i++)
        {
            AddButton();
        }
    }

    public void AddButton()
    {
        var but = ButtonPoolController.Instance.GetButton("Кнопка " + (buttons.Count+1).ToString());
        buttons.Push(but);

    }

    public void DeleteButton()
    {
        if(buttons.Count > 0)
            ButtonPoolController.Instance.ReturnToPool(buttons.Pop());
    }
}
