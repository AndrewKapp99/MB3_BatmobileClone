using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    private float _percentage;
    public Cannon cann;

    private void Update()
    {
        _percentage = cann._t / cann.coolDown;

        GetComponent<Image>().fillAmount = _percentage;
    }
}
