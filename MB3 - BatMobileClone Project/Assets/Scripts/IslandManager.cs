using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    private GameObject[] _allTargets, _allEnemies;
    private List<GameObject> _targets, _enemies;
    public int numTarget, numEnemy;
    private void Start()
    {
        _allTargets = GameObject.FindGameObjectsWithTag("Target");
        _allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        _targets = new List<GameObject>();
        _enemies = new List<GameObject>();

        foreach (var x in _allTargets)
        {
            if (x.transform.parent == this.transform)
            {
                _targets.Add(x);
            }
        }

        foreach (var x in _allEnemies)
        {
            if (x.transform.parent == this.transform)
            {
                _enemies.Add(x);
            }
        }

        numTarget = _targets.Count;
        numEnemy = _enemies.Count;
    }

    private void Recount()
    {
        numTarget = _targets.Count;
        numEnemy = _enemies.Count;
    }

    public void RemoveTarget(GameObject obj)
    {
        _targets.Remove(obj);
        Recount();
    }

    public void RemoveEnemy(GameObject obj)
    {
        _enemies.Remove(obj);
        Recount();
    }
}
