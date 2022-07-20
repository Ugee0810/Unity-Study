using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovingObject
{
    public int health = 100;
    public int foodEnergy = 10;
    public int wallDamage = 1;

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

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        health--;
        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;
        if (Move(xDir, yDir, out hit))
        {

        }
    }

    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;

        hitWall.DamageWall(wallDamage);

        animator.SetTrigger("State");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            health += foodEnergy;
            collision.gameObject.SetActive(false); // 오브젝트와 닿은 오브젝트는 비활성화
        }
    }
}
