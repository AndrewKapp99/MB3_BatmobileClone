using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakpoint : MonoBehaviour
{
    public GameObject mainTank;
    [SerializeField] private MeshRenderer exposable;
    [SerializeField] private Material exposedMat;
    public void OnDestroy()
    {
        if (exposable == null)
        {
            Destroy(mainTank);
            return;
        }
        exposable.material = exposedMat;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit");
        Destroy(this.gameObject);
    }
}
