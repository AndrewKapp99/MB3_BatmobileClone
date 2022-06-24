using UnityEngine;

public class destinationManager : MonoBehaviour
{
    [SerializeField] private EnemyNav targetEnemy;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Somethings inside me");
        if (other.gameObject == targetEnemy.gameObject)
        {
            
            targetEnemy.NextPosition();
        }
    }
}
