using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponentInChildren<Text>();
    }

    public void SetText(string desc)
    {
        text.text = desc;
    }
}
