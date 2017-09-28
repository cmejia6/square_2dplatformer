using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RigidControllerNetwork : GeneralMovementNetwork {
    Rigidbody2D rigid;
    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    [SerializeField]
    Color startColor;
    public override void OnStartLocalPlayer() {
        transform.Find("sprite").GetComponent<SpriteRenderer>().color = startColor;
    }

    bool canJump = true;
    bool inAir;

    //flag so it doesnt have to use a raycast every frame
    bool checkedLayer;
    bool onPlatformLayer;
    void FixedUpdate() {
        if (!isLocalPlayer)
            return;

        if (KeyboardAxis == Vector2.zero && checkedLayer == false
            && CheckCollision(Collision.Bottom) && CollidingWith.layer == LayerMask.NameToLayer("stick")) {
            Debug.Log("checking");

            onPlatformLayer = true;
            checkedLayer = true;
        }

        if (KeyboardAxis == Vector2.zero && onPlatformLayer == true) {
            rigid.velocity = CollidingWith.GetComponent<Rigidbody2D>().velocity;
        }
        else {
            Move();

            checkedLayer = false;
            onPlatformLayer = false;
        }

        if (canJump == true && KeyboardAxis.y == 1
            && inAir == false && CheckCollision(Collision.Bottom)) {

            inAir = true;

            rigid.velocity = new Vector2(rigid.velocity.x / 2.5f, jumpForce);
        }

        //if jump is finished and player had landed
        if (KeyboardAxis.y == 0 && inAir == true && CheckCollision(Collision.Bottom) == true) {
            inAir = false;
        }
    }

    [SerializeField]
    float force = 80;
    [SerializeField]
    float maxXVelocity = 100;
    void Move() {
        if (Mathf.Abs(rigid.velocity.x) < maxXVelocity && KeyboardAxis.x != 0) {
            rigid.AddForce(new Vector2(KeyboardAxis.x * force, 0));
        }
        else if (KeyboardAxis.x == 0 && Mathf.Abs(rigid.velocity.x) > 5) {
            if (rigid.velocity.x > 0) {
                rigid.velocity = new Vector2(rigid.velocity.x - 10, rigid.velocity.y);
            }
            else if (rigid.velocity.x < 0) {
                rigid.velocity = new Vector2(rigid.velocity.x + 10, rigid.velocity.y);
            }
        }
        else if (Mathf.Abs(rigid.velocity.x) < 5) {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
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

    bool onPlatform;
    public bool OnPlatfrom {
        set {
            onPlatform = value;
        }
    }

    public float MaxXVelocity {
        get {
            return maxXVelocity;
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
