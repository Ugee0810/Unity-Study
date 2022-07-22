using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour // 움직이는 물체의 공통 추상 클래스
{
    public float moveTime = 0.1f;
    public LayerMask blockingLayer; // blockingLayer 충돌 판단

    private BoxCollider2D bc2d;
    private Rigidbody2D   rb2d;
    private float inverseMoveTime;
    private bool  isMoving;

    protected virtual void Start() // 상속 받아 변경하기 위해 protected virtual로 정의
    {
        bc2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        inverseMoveTime = 1f / moveTime;
    }

    protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end   = start + new Vector2(xDir, yDir);

        bc2d.enabled = false; // 움직일 때 자신이 걸리지 않도록 비활성화
        hit = Physics2D.Linecast(start, end, blockingLayer); // blockingLayer에서 start와 end 사이의 충돌을 반환

        bc2d.enabled = true;

        if (hit.transform == null && !isMoving) // 움직이는 물체가 걸린다면 stop
        {
            StartCoroutine(SmoothMovement(end));

            return true;
        }
        return false;
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        isMoving = true;

        float sqrRemainingDistance = (transform.position - end).sqrMagnitude; // 남은 거리 계산 | sqrMagnitude - 정확한 거리 보다 거리간 비교용으로 사용(A와 B간의 거리가 특정 거리보다 작거나 큰지 비교만 함(성능))
        while (sqrRemainingDistance > float.Epsilon) // Epsilon : 0과 매우 가까운 수
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2d.position, end, inverseMoveTime + Time.deltaTime);
            rb2d.MovePosition(newPosition);

            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            
            yield return null;
        }

        rb2d.MovePosition(end);

        isMoving = false;
    }

    protected virtual void AttemptMove <T> (int xDir, int yDir) where T : Component
    {
        RaycastHit2D hit;

        bool canMove = Move(xDir, yDir, out hit);

        if (hit.transform == )
    }


    void Update()
    {
        
    }
}
