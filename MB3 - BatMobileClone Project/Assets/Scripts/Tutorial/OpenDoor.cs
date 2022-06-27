using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenDoor : MonoBehaviour
{
    private IslandManager _im;
    [SerializeField] private Transform door;

    private void Start()
    {
        _im = GetComponent<IslandManager>();
    }

    private void Update()
    {
        var num = _im.numTarget;

        if (num == 0)
        {
            door.DOLocalMoveX(-3.4f, 0.75f, false);
        }
    }
}
