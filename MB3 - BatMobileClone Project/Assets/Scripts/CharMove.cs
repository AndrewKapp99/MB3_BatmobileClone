using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    #region Values
    [Header("Movement")]
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float Weight;
    [SerializeField] private float ForceOutput;
    [SerializeField] public bool BattleMode;
    [SerializeField] private float BattleSpeed;
    private Vector3 moveVec;
    private bool jumping;
    private Rigidbody rb;

    public Vector2 InVector;

    [Header("Camera")]
    [SerializeField] private Transform CamAnchor;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform PlayerMesh;
    private Vector3 lookVec;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

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

        #region Movement
        rb.AddForce(d.normalized * ForceOutput);

        if (rb.velocity.magnitude >= MaxSpeed)
        {
            rb.AddForce(-(rb.velocity.normalized) * ForceOutput);
        }
        if (rb.velocity.magnitude >= BattleSpeed && BattleMode)
        {
            rb.AddForce(-(rb.velocity.normalized) * ForceOutput);
        }

        #endregion

        #region Camera Management
        if (rb.velocity.magnitude >= 0.5f && InVector.magnitude != 0 && BattleMode)
        {
            PlayerMesh.localRotation = Quaternion.Lerp(Quaternion.LookRotation(CamFwd), PlayerMesh.localRotation, 0.01f);
        }
        #endregion
    }

    public void Update()
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

        CamAnchor.localEulerAngles = angles;

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
        double inD = input.Get<double>();
        BattleMode = !BattleMode;
    }

    public void OnLook(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        lookVec = new Vector3(inputVec.y, inputVec.x, 0f);
    }
}
