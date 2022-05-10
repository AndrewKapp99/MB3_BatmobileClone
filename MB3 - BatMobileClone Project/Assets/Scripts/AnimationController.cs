using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public Vector2 BlenderVector;
    public bool BattleMode;

    private CharMove cm;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponentInParent<CharMove>();
    }

    // Update is called once per frame
    void Update()
    {
        BattleMode = cm.BattleMode;
        BlenderVector = cm.InVector;

        anim.SetFloat("x", BlenderVector.x);
        anim.SetFloat("y", BlenderVector.y);

        anim.SetBool("Battle", BattleMode);
    }
}
