using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        transform.parent.GetComponent<IslandManager>().RemoveEnemy(this.gameObject);
        Destroy(this.gameObject);
    }
}
