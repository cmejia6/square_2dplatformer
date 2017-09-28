using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollMovContV0 : GeneralMovementv0 {
    Collider2D collider;
    void Awake() {
        collider = GetComponent<Collider2D>();
    }

    void Move(Vector2 velocity) {
        transform.position += new Vector3(velocity.x, IsGrounded ? 0 : velocity.y);
    }

    bool IsGrounded {
        get {
            return true;
        }
    }

    void Update() {
        Debug.Log(collider.IsTouchingLayers(Physics2D.AllLayers));
        Move(new Vector2(KeyboardAxis.x, -5));
    }
}