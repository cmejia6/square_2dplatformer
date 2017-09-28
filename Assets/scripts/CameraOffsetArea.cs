using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffsetArea : MonoBehaviour {

    BoxCollider2D boxCollider;
    CameraSinglePlayer singleCam;
    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = areaSize;

        singleCam = Camera.main.GetComponent<CameraSinglePlayer>();
    }

    [SerializeField]
    Transform camTarget;

    [SerializeField]
    Vector2 areaSize = new Vector2(64, 64);

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            singleCam.Target = camTarget;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            singleCam.Target = collision.transform;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, areaSize);
        Gizmos.color = Color.gray;

        if (camTarget != null) {
            Gizmos.DrawLine(transform.position, camTarget.position);
        }
    }
}
