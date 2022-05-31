using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
