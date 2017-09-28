using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour {
    public static DeathPit Instance { get; set; }
    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log(coll.name + " had been destroyed");
        coll.transform.SetParent(transform);
        coll.gameObject.SetActive(false);

        if (coll.CompareTag("Player")) {
            GeneralGameManager.Instance.RestartLevel();
        }
    }

    void OnDrawGizmos() {
        if (Instance == null) Instance = this;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(transform.position.x -1000, transform.position.y), new Vector3(transform.position.x + 1000, transform.position.y));
    }
}
