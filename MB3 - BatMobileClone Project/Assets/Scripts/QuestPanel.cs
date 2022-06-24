using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    public IslandManager island;
    public GameObject prefab;
    public Sprite targetIcon, enemyIcon;

    private int _target, _enemy;
    private ComponentPanel _targetTracker, _enemyTracker;
    private GameObject _targetT, _enemyT;

    private void Start()
    {
        _target = island.numTarget;
        _enemy = island.numEnemy;

        _targetT = Instantiate(prefab, this.transform);
        _targetTracker = _targetT.GetComponent<ComponentPanel>();

        _enemyT = Instantiate(prefab, this.transform);
        _enemyTracker = _enemyT.GetComponent<ComponentPanel>();
    }

    private void Update()
    {
        
    }
}