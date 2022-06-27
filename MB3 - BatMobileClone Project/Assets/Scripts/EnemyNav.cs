using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private NavMeshAgent _nmAgent;
    [SerializeField] private List<Transform> destinations;

    public int _currentPos = 0;

    private void Awake()
    {
        _nmAgent = GetComponent<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        foreach (var x in destinations)
        {
            Destroy(x.gameObject);
        }
    }

    private void OnEnable()
    {
        _currentPos = FindClosest();

    }

    private void Update()
    {
        _nmAgent.destination = destinations[_currentPos].position;
    }

    public void NextPosition()
    {
        _currentPos++;
        if (_currentPos == destinations.Count)
            _currentPos = 0;
    }

    private int FindClosest()
    {
        float temp = Vector3.Distance(transform.position, destinations[0].position);
        int index = 0;
        for (int i = 0; i < destinations.Count; i++)
        {
            if (Vector3.Distance(transform.position, destinations[i].position) < temp)
            {
                index = i;
            }
        }

        return index;
    }
}
