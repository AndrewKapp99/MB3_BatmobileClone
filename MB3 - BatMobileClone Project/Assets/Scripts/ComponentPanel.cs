using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentPanel : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Text txt;

    private Sprite _icon;
    private string _str;

    public void SetValues(Sprite spr, string str)
    {
        _icon = spr;
        _str = str;
    }

    public void SetIcon(Sprite icon)
    {
        _icon = icon;
        img.sprite = icon;
    }

    public void SetNumber(string str)
    {
        _str = str;
        txt.text = str;
    }
}
