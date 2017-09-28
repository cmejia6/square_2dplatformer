using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSinglePlayer : MonoBehaviour {
    Transform player;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //for now it just gets the player, you can plug in a target if you want 
    Transform target;
    private void Start() {
        target = player;
    }

    Vector2 offset = new Vector2(0, 48);
    private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10) + (Vector3)offset, .4f);
    }

    public Transform Target {
        set {
            target = value;
        }
    }

    public Vector2 Offset {
        set {
            offset = value;
        }
    }
}