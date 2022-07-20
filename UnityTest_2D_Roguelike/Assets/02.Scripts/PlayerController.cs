using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovingObject
{
    private Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();

        base.Start();
    }

    void Update()
    {
        int horizontal = 0;
        int vertical   = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical   = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0) // 좌, 우로 움직이고 있다면,
            vertical = 0; // 상, 하는 이동 불가

        if (horizontal != 0 || vertical != 0) // 움직일 때 마다
        {
            //AttemptMove<Wall>(horizontal, vertical);
        }

    }

    protected override void OnCantMove<T>(T component)
    {
        throw new System.NotImplementedException();
    }
}
