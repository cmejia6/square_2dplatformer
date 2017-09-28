using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFireV0 : MonoBehaviour {
    Vector2 spawnPos;
    private void Start() {
        spawnPos = transform.position;
    }

    private void Update() {
        if (Vector2.Distance(spawnPos, transform.position) >= 112) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player") == false && collision.GetComponent<HealthSystem>() != null) {
            collision.GetComponent<HealthSystem>().HP -= 1;
        }
    }
}
