using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using Pattern.Utility;

public class Cannon : MonoBehaviour
{
    public Rigidbody body;
    public Transform Camera, barrel, target;
    public GameObject Projectile;
    public GameObject Flash;
    public Transform LaunchPnt;
    public float ProjectileSpeed;
    
    public float coolDown;

    private Vector3 _angles;
    private float _incAngle;

    public float _t;
    void OnEnable()
    {
        GetComponent<PlayerInput>().enabled = true;
        transform.rotation = Quaternion.Euler(new Vector3(-90f, Camera.rotation.y, 0f));
        barrel.LookAt(target);
    }

    void OnDisable()
    {
        GetComponent<PlayerInput>().enabled = false;
        transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        barrel.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angles = (Camera.rotation.eulerAngles);
        //angles.x = angles.x - 90;
        barrel.localRotation = Quaternion.Euler(new Vector3(angles.x, 0f, 0f));
        transform.rotation = Quaternion.Euler(new Vector3(-90, angles.y, 0f));

        if (_t > 0)
        {
            _t -= Time.deltaTime;
        }
        
        LaunchPnt.LookAt(target);
    }

    private void OnFire()
    {
        if (_t <= 0)
        {
            _angles = Camera.forward;
            GameObject mFlash = Instantiate(Flash, LaunchPnt.position, LaunchPnt.rotation);
            GameObject newRound = Instantiate(Projectile, LaunchPnt.position, Quaternion.Euler(LaunchPnt.rotation.eulerAngles + new Vector3(90f, 0f, 0f)));
            Rigidbody newRB = newRound.GetComponent<Rigidbody>();
            newRB.velocity = ProjectileSpeed * _angles;
            _t = coolDown;
        }
    }
}
