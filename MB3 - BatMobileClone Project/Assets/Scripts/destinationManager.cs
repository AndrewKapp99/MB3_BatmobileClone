using UnityEngine;

public class destinationManager : MonoBehaviour
{
    [SerializeField] private EnemyNav targetEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetEnemy.gameObject)
        {
            
            targetEnemy.NextPosition();
        }
    }
}
