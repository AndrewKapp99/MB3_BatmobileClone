using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PursuitMode : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> Axles;
    [SerializeField] float PowerDistribution = 0.5f;
    [SerializeField] float Power, MaxSteeringAngle, BrakingForce, BrakingDistribution;


    private float RearPowerDist, FrontPowerDist, InputIntensity, steeringIn, steering, FrontBrakeDist, BackBrakeDist;
    private bool braking = false;

    // Start is called before the first frame update
    void Start()
    {
        FrontPowerDist = 1 - PowerDistribution;
        RearPowerDist = PowerDistribution;
        FrontBrakeDist = 1 - BrakingDistribution;
        BackBrakeDist = BrakingDistribution;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float steer = steeringIn * MaxSteeringAngle;
        float motor = InputIntensity * Power;


        foreach (AxleInfo axleInfo in Axles)
        {
            if (axleInfo.steer)
            {
                axleInfo.LeftWheel.steerAngle = steer;
                axleInfo.RightWheel.steerAngle = steer;
            }
            if (axleInfo.motor)
            {
                axleInfo.LeftWheel.motorTorque = motor;
                axleInfo.RightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.LeftWheel, axleInfo.LeftWheelT);
            ApplyLocalPositionToVisuals(axleInfo.RightWheel, axleInfo.RightWheelT);
        }
    }

    public void OnAccelerate(InputValue input)
    {
        InputIntensity = input.Get<float>();

    }

    public void OnSteering(InputValue input)
    {
        steeringIn = input.Get<Vector2>().x;
        Debug.Log("Turning Now " + steeringIn);
    }

    public void OnBrake()
    {
        braking = !braking;
        Debug.Log(braking);
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.transform.position = position;
        transform.transform.rotation = rotation;
    }

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider LeftWheel;
    public Transform LeftWheelT;
    public WheelCollider RightWheel;
    public Transform RightWheelT;
    public bool motor;
    public bool steer;
}
