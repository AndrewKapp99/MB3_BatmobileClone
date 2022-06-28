using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIsland : MonoBehaviour
{
    [SerializeField] private QuestPanel questPanel;
    [SerializeField] private IslandManager island;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questPanel.island = island;
            questPanel.RecountAll();
        }
    }
}
