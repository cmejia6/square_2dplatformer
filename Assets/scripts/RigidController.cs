using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidController : GeneralMovementv0 {
    Rigidbody2D rigid;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    bool canJump = true;
    bool inAir;

    //flag so it doesnt have to use a raycast every frame
    bool checkedLayer;
    bool onPlatformLayer;

    float distFromWall;
    Vector2 wallPos;
    void FixedUpdate() {

        if (KeyboardAxis == Vector2.zero && checkedLayer == false
            && CheckCollision(Collision.Bottom) && CollidingWith.layer == LayerMask.NameToLayer("stick")) {

            onPlatformLayer = true;
            checkedLayer = true;
        }

        if (KeyboardAxis == Vector2.zero && onPlatformLayer == true) {
            rigid.velocity = CollidingWith.GetComponent<Rigidbody2D>().velocity;
        }

        //jumping towards wall stuff
        //player gets stuck to wall while jumping
        else if (inAir == true && Mathf.Abs(wallPos.x - transform.position.x) > 0.1f 
            && ((CheckCollision(Collision.Right, 0.5f) && KeyboardAxis.x != -1) || (CheckCollision(Collision.Left, 0.5f) && KeyboardAxis.x != 1))) {

            Debug.Log("wall");
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
        else {
            Move();

            checkedLayer = false;
            onPlatformLayer = false;
        }

        //jumping
        if (canJump == true && KeyboardAxis.y == 1
            && inAir == false && CheckCollision(Collision.Bottom)
            && (CheckCollision(Collision.Top) ? CollidingWith.transform.tag != "Player" : true)) {

            CheckCollision(Collision.Top);

            inAir = true;

            //jumping towards wall stuff
            if (CheckCollision(Collision.Right) || CheckCollision(Collision.Left) ) {
                if (CheckCollision(Collision.Right)) {
                    rigid.velocity = new Vector2(-28, jumpForce);
                }
                else if (CheckCollision(Collision.Left)) {
                    rigid.velocity = new Vector2(28, jumpForce);
                }

                wallPos = transform.position;
            }
            else {
                rigid.velocity = new Vector2(rigid.velocity.x / 2f, jumpForce);
            }
        }

        //if jump is finished and player had landed
        if (KeyboardAxis.y == 0 && inAir == true && CheckCollision(Collision.Bottom) == true) {
            inAir = false;
        }
    }

    [SerializeField]
    float force = 80;
    [SerializeField]
    float maxXVelocity= 100;
    Vector2 lastDir;
    void Move() {
        if (Mathf.Abs(rigid.velocity.x) < maxXVelocity && KeyboardAxis.x != 0) {
            rigid.AddForce(new Vector2(KeyboardAxis.x * force, 0));
        }
        else if (KeyboardAxis.x == 0 && Mathf.Abs(rigid.velocity.x) > 10) {
            if (rigid.velocity.x > 0) {
                rigid.velocity = new Vector2(rigid.velocity.x - 25, rigid.velocity.y);
            }
            else if (rigid.velocity.x < 0) {
                rigid.velocity = new Vector2(rigid.velocity.x + 10, rigid.velocity.y);
            }
        }
        else if (Mathf.Abs(rigid.velocity.x) < 10) {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

        //only works for x axis
        if (KeyboardAxis.x != 0) {
            lastDir = KeyboardAxis;
        }
    }

    void OnPlatformMove() {
        rigid.MovePosition(CollidingWith.transform.position);
        rigid.AddForce(new Vector2(KeyboardAxis.x * force, 0));
    }

    [SerializeField]
    float jumpForce = 500;

    //not used
    [SerializeField]
    float jumpThreshold = 32;

    public float MaxXVelocity {
        get {
            return maxXVelocity;
        }
    }

    public Vector2 LastDir {
        get {
            return lastDir;
        }
    }

    public bool CanJump {
        set {
            canJump = value;
        }
    }

    public bool InAir {
        get {
            return inAir;
        }
    }
}