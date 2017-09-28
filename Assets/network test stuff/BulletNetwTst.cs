using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNetwTst : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision) {
        var hit = collision.gameObject;
        var hitCombat = hit.GetComponent<CombatNetwTst>();
        if (hitCombat != null) {

            hitCombat.TakeDamage(10);

            Destroy(gameObject);
        }
    }
}
