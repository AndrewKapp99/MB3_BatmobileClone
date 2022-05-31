using UnityEngine;

public class RotateToFace : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cam;
    void Update()
    {
        Vector3 v = cam.forward;
        v.x = 0f;
        v.z = 0f;
        /*if (rb.velocity.magnitude > 0.1)
        {
            v = new Vector3(transform.localRotation.x, transform.localRotation.y + Time.deltaTime,
                transform.localRotation.z);
        }*/
        
        transform.localRotation = Quaternion.Euler(v);
    }
}
