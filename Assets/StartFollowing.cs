using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFollowing : MonoBehaviour {
    [SerializeField] NPCBehaviour npcBehaviour;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            npcBehaviour.CopyTargetVelocity(.5f);
        }
    }
}
