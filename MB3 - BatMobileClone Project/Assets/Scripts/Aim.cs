using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        var hit = new RaycastHit();
        var temp = new Vector3();
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 330f))
        {
            temp = hit.point;
        }

        target.position = temp;
    }
}
