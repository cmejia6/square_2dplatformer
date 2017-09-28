using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFriendMagV0 : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Player") {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; i++) {
                if (players[i] != coll.gameObject) {
                    players[i].transform.position = transform.position;
                }
            }

        }
    }
}
