using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour {
    Transform player;
    Rigidbody2D rigid;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool copyVelocity = false;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            copyVelocity = true;
            CopyTargetVelocity(.5f);
        }

        if (copyVelocity == true) {
            recordedVelocity.Add(player.GetComponent<Rigidbody2D>().velocity);
            Debug.Log("following");
        }
    }

    List<Vector2> recordedVelocity = new List<Vector2>();
    public void CopyTargetVelocity (float delay) {
        copyVelocity = true;
        StartCoroutine(PlayVelocity(delay));
    }

    IEnumerator PlayVelocity (float cDelay) {
        int current= 0;
        yield return new WaitForSeconds(cDelay);

        while (current < recordedVelocity.Count) {
            rigid.velocity = recordedVelocity[current];
            current++;
            yield return null;
        }
    }
}
