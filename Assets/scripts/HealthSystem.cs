using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    [SerializeField]
    int hp;

    private void Update() {
        if (hp <= 0) {
            Die();
        }
    }

    void Die() {
        gameObject.SetActive(false);

        if (transform.CompareTag("Player")) {
            GeneralGameManager.Instance.RestartLevel();
        }

    }

    public int HP {
        get {
            return hp;
        }

        set {
            hp = value;
        }

    }
}
