using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class CamManager : MonoBehaviour
{
    [SerializeField] private Transform Camera, PlayerMesh, CamAnchor;
    //public Vector3 A, B;
    public float time, waitTime;
    //public int radius;
    private Quaternion prevRotation;
    //public float theta, dist;
    public bool Moving, Able, Aligned;

    private float t;
    private CharMove cm;
    private Vector3 lookVec;
    // Start is called before the first frame update
    void Start()
    {
        prevRotation = Camera.rotation;
        cm = GetComponent<CharMove>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Camera
        Vector3 angles = CamAnchor.localEulerAngles + lookVec;
        float angle = (CamAnchor.localEulerAngles + lookVec).x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }
        angles.z = 0f;

        CamAnchor.localEulerAngles = angles;

        #endregion

        Able = cm.Underpower;
        #region Stationary Camera Check
        if (!Moving)
        {
            t += Time.deltaTime;
        }
        else if (Moving)
        {
            t = 0;
        }

        if (prevRotation != Camera.rotation)
        {
            Moving = true;
            Debug.Log("I am Rotating");
        }
        else
            Moving = false;

        if (PlayerMesh.rotation.eulerAngles.y == Camera.rotation.eulerAngles.y)
        {
            Aligned = true;
        }
        else
            Aligned = false;

        if (Able && !Moving && !Aligned)
        {
            RotateToFace();
            t = 0;
        }

        prevRotation = Camera.rotation;
        #endregion
    }

    public void RotateToFace()
    {
        PlayerMesh.DORotate(new Vector3(0f, Camera.eulerAngles.y, 0f), time);
    }

    public void OnLook(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        lookVec = new Vector3(inputVec.y, inputVec.x, 0f);
    }
}
