using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    #region Values
    [Header("Movement")]
    [SerializeField] private float MaxSpeed;
    [SerializeField][Range(0.0f, 1.0f)] private float throttle;
    public Transform ThrottlePoint, SteeringPoint;
    public float SteeringDirection, TurnForce;
    [SerializeField] private float Weight;
    [SerializeField] private float ForceOutput;
    [SerializeField] public bool BattleMode;
    [SerializeField] private float BattleSpeed;
    private Vector3 moveVec;
    private Rigidbody rb;

    public Vector2 InVector;

    [Header("Camera")]
    [SerializeField] private Transform CamAnchor;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform PlayerMesh;
    public Vector3 lookVec;

    [Header("Misc")]
    public bool Underpower;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        /*#region Camera
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

        #endregion*/
        #region Boolean Control
        if (InVector.magnitude != 0 && BattleMode)
        {
            Underpower = true;
        }
        else
        {
            Underpower = false;
        }
        #endregion
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 CamFwd = Camera.forward;
        Vector3 CamRt = Camera.right;

        CamFwd.y = 0f;
        CamRt.y = 0f;

        moveVec = moveVec.normalized;

        Vector3 d = (CamFwd * moveVec.z + CamRt * moveVec.x);

        #region Movement - BattleMode
        if (BattleMode)
        {
            rb.AddForce(d.normalized * ForceOutput);
            if (rb.velocity.magnitude >= BattleSpeed && BattleMode)
            {
                rb.AddForce(-(rb.velocity.normalized) * ForceOutput);
            }
        }
        #endregion
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        InVector = inputVec;

        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
    }

    public void OnSwitchMode(InputValue input)
    {
        BattleMode = !BattleMode;
    }


}
