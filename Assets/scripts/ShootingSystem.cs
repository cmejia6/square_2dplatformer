using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {
    [SerializeField]
    GameObject shotFab;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Shoot();
        }
    }

    void Shoot() {
        var t = Instantiate(shotFab, transform.position, Quaternion.identity);
        t.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<RigidController>().LastDir.x * 200, 0);
    }
}