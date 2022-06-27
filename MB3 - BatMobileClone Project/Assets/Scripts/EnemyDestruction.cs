using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
