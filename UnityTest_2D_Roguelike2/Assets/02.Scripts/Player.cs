using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public int wallDamage = 1;

    private Animator animator;
    private int food;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        food = GameManager.instance.playerFoodPoints;

        base.Start();
    }

    void OnDisable()
    {
        GameManager.instance.playerFoodPoints = food;
    }

    void Update()
    {
        if (!GameManager.instance.playersTurn) return;

        int horizontal = 0;
        int vertical   = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical   = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0) // Player가 이동 중이라면
        {
            AttemptMove<Wall>(horizontal, vertical);
        }
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        food--;

        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        Move(xDir, yDir, out hit);

        CheakIfGameOver();

        GameManager.instance.playersTurn = false;
    }

    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;

        hitWall.DamageWall(wallDamage);

        animator.SetTrigger("PlayerAttack");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            enabled = false; // OnDisable() 메서드 호출
        }
        else if(collision.tag == "Food")
        {
            food += pointsPerFood;
            collision.gameObject.SetActive(false);
        }
        else if(collision.tag == "Soda")
        {
            food += pointsPerSoda;
            collision.gameObject.SetActive(false);
        }
    }

    private void CheakIfGameOver()
    {
        if (food <= 0)
        {
            GameManager.instance.GameOver();
        }    
    }

    public void LoseFood(int loss) // Enemy에게 피격 당했을 때 음식을 잃는다.
    {
        animator.SetTrigger("PlayerHit");

        food -= loss;

        CheakIfGameOver();
    }
}