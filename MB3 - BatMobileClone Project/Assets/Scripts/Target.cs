using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnDestroy()
    {
        var temp = transform.parent.gameObject.GetComponent<IslandManager>();
        temp.RemoveTarget(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
