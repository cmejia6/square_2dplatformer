using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviourV0 : GeneralMovementv0 {
    Rigidbody2D rigid;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    bool attachedToPlayer;
    bool inContactWithPlayer;
    void FixedUpdate() {
        if (attachedToPlayer == true) {
            Rigidbody2D playerRigid = playerOnTop.GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector2(playerRigid.velocity.x, 0);
        }
        else if (rigid.velocity != Vector2.zero && inContactWithPlayer == false && CheckCollision(Collision.Bottom)
            && CollidingWith.layer == LayerMask.NameToLayer("stick")) {
            rigid.velocity = CollidingWith.GetComponent<Rigidbody2D>().velocity;
        }
    }

    Transform playerOnTop;
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.transform.tag == "Player" && coll.transform.GetComponent<RigidController>().InAir == false
            && coll.transform.GetComponent<GeneralMovementv0>().CheckCollision(GeneralMovementv0.Collision.Top) == true) {

            attachedToPlayer = true;
            playerOnTop = coll.transform;
            playerOnTop.GetComponent<RigidController>().CanJump = false;

            rigid.bodyType = RigidbodyType2D.Kinematic;
            transform.position = new Vector2(playerOnTop.position.x, playerOnTop.position.y + 18);
        }
        else if (coll.transform.tag == "Player") {
            inContactWithPlayer = true;
        }

        if (attachedToPlayer == true && coll.transform.tag == "Player"
            && (coll.transform.GetComponent<GeneralMovementv0>().CheckCollision(GeneralMovementv0.Collision.Left)
            || coll.transform.GetComponent<GeneralMovementv0>().CheckCollision(GeneralMovementv0.Collision.Right))){

            playerOnTop.GetComponent<RigidController>().CanJump = true;
            playerOnTop = null;

            rigid.bodyType = RigidbodyType2D.Dynamic;

            attachedToPlayer = false;
            transform.GetComponent<Rigidbody2D>().AddForce(coll.transform.position.x > transform.position.x ? new Vector2(-4000, 500) : new Vector2(4000, 500));
        }
    }

    void OnCollisionExit2D(Collision2D coll) {
        if (coll.transform.tag == "Player") {
            inContactWithPlayer = false;
        }
    }

}
