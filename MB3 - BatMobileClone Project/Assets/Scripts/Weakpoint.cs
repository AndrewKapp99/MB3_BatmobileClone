using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakpoint : MonoBehaviour
{
    public GameObject mainTank;
    [SerializeField] private Weakpoint exposable;
    [SerializeField] private Material exposedMat;
    public void OnDestroy()
    {
        if (exposable == null)
        {
            Destroy(mainTank);
            return;
        }
        exposable.Expose();
    }

    public void Expose()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<MeshRenderer>().material = exposedMat;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
