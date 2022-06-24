using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    private GameObject[] _allTargets;
    private List<GameObject> _targets;
    public int numTarget, numEnemy;
    private void Start()
    {
        _allTargets = GameObject.FindGameObjectsWithTag("Target");
        _targets = new List<GameObject>();

        foreach (var x in _allTargets)
        {
            if (x.transform.parent == this.transform)
            {
                _targets.Add(x);
            }
        }

        numTarget = _targets.Count;
    }

    private void Recount()
    {
        numTarget = _targets.Count;
    }

    public void Remove(GameObject obj)
    {
        _targets.Remove(obj);
        Recount();
    }
}
