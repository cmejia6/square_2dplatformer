using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour {

    [SerializeField]
    float jumpForce = 200;
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) {
            //RigidController rigidController = collision.GetComponent<RigidController>();
            Rigidbody2D rg = collision.GetComponent<Rigidbody2D>();

            //with velocity
            rg.velocity = new Vector2(rg.velocity.x, jumpForce);

            Debug.Log("should bounce");
        }
    }
}
