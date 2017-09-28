using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy0 : GeneralMovementv0 {
    Rigidbody2D rigid;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>(); 
    }

    Vector2 ogPos;
    private void Start() {
        ogPos = transform.position;
    }

    private void FixedUpdate() {
        MoveBackOnCorner();
    }

    bool moveRight;
    void MoveBackOnCorner() {
        Debug.Log(Physics2D.OverlapBox((Vector2)transform.position + new Vector2(0, -8), Vector2.one, 0));

        if ((transform.position.x < ogPos.x && Physics2D.OverlapBox((Vector2)transform.position + new Vector2(-6, -8), Vector2.one, 0) == null)
            || (transform.position.x > ogPos.x && Physics2D.OverlapBox((Vector2)transform.position + new Vector2(6, -8), Vector2.one, 0) == null)
            || CheckCollision(Collision.Right) || CheckCollision(Collision.Left)) {

            moveRight = !moveRight;
        }

        if (moveRight == true) {
            rigid.velocity = new Vector2(20, rigid.velocity.y);
        }
        else {
            rigid.velocity = new Vector2(-20, rigid.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            collision.transform.GetComponent<HealthSystem>().HP -= 1;
        }
    }
}