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
    [SerializeField] private bool BattleMode;
    [SerializeField] private float BattleSpeed;
    private Vector3 moveVec;
    private bool jumping;
    private Rigidbody rb;

    [Header("Camera")]
    [SerializeField] private Transform CamAnchor;
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
        #region Movement
        rb.AddForce(moveVec * ForceOutput);

        if (rb.velocity.magnitude >= MaxSpeed)
        {
            rb.AddForce(-(rb.velocity.normalized) * ForceOutput);
        }
        if (rb.velocity.magnitude >= BattleSpeed && BattleMode)
        {
            rb.AddForce(-(rb.velocity.normalized) * ForceOutput);
        }

        #endregion
    }

    public void Update()
    {
        #region Camera
        Vector3 angles = CamAnchor.localEulerAngles + lookVec;
        float angle = (CamAnchor.localEulerAngles + lookVec).x;

        Debug.Log(CamAnchor.localEulerAngles);

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

        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
    }

    public void OnSwitchMode(InputValue input)
    {
        BattleMode = !BattleMode;
    }

    public void OnLook(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        lookVec = new Vector3(inputVec.y, inputVec.x, 0f);
    }
}
