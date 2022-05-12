using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PursuitMode : MonoBehaviour
{
    public float throttle, MaxSpeed, ForceOutput, TurnForce, SteeringDirection;
    private Rigidbody rb;
    public Transform PlayerMesh, ThrottlePoint, SteeringPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (throttle > 0)
        {
            rb.AddForceAtPosition((PlayerMesh.forward * ForceOutput) * throttle, ThrottlePoint.position);
            if (rb.velocity.magnitude >= MaxSpeed)
            {
                rb.AddForce(-(rb.velocity.normalized) * ForceOutput);
            }
        }
        if (SteeringDirection != 0)
            rb.AddForceAtPosition(PlayerMesh.right * TurnForce * SteeringDirection, SteeringPoint.position);
    }

    public void OnAccelerate(InputValue input)
    {
        float intensity = input.Get<float>();
        throttle = intensity;
    }

    public void OnSteering(InputValue input)
    {
        Vector2 inVec = input.Get<Vector2>();
        SteeringDirection = inVec.x;
    }
}
