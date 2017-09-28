using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatformRgd : MonoBehaviour {
    Rigidbody2D rigid;
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate() {
        if (plyerOnTop == true) {
            //player[i].GetComponent<Rigidbody2D>().velocity = rigid.velocity;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(rigid.velocity.x, 0);
            Debug.Log("player on top");
        }
    }

    bool plyerOnTop;
    Transform player;
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.transform.tag == "Player"
            && coll.transform.GetComponent<GeneralMovementv0>().CheckCollision(GeneralMovementv0.Collision.Bottom) == true
            && coll.transform.GetComponent<GeneralMovementv0>().CollidingWith == gameObject) {

            plyerOnTop = true;
            player = coll.transform;

            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            player.transform.position = new Vector2(transform.position.x, transform.position.y + 18);
        }
    }
}
