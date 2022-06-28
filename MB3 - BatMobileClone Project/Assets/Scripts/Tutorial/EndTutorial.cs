using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutPanel;

    private void OnTriggerEnter(Collider other)
    {
        tutPanel.SetActive(false);
    }
}
