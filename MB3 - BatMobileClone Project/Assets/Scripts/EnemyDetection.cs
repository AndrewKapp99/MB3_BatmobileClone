using UnityEngine;
using UnityEngine.AI;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float detectionRadius;
    public float lossRadius;

    private NavMeshAgent _nmAgent;
    private EnemyNav _en;
    private bool _found;

    private void Awake()
    {
        _nmAgent = GetComponent<NavMeshAgent>();
        _en = GetComponent<EnemyNav>();
    }
    
    private void Update()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionRadius)
        {
            _found = true;
        }

        if (distance >= lossRadius)
        {
            LoseTarget();
        }

        if (_found)
        {
            _en.enabled = false;
            _nmAgent.destination = player.transform.position;
        }
    }

    private void LoseTarget()
    {
        _en.enabled = true;
        _found = false;
    }
}
