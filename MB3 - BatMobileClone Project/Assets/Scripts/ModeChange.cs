using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModeChange : MonoBehaviour
{
    private CharMove cm;
    private PursuitMode pm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CharMove>();
        pm = GetComponent<PursuitMode>();
    }

    public void OnSwitchMode(InputValue input)
    {
        cm.enabled = !cm.enabled;
        pm.enabled = !pm.enabled;
    }
}
