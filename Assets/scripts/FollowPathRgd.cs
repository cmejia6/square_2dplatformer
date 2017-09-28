using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowPathRgd : MonoBehaviour {
    Rigidbody2D rigid;

    [SerializeField]
    bool runOnStart = true;
    [SerializeField]
    bool runOnCollision;

    [SerializeField]
    bool loop;

    GameObject[] players;

    [SerializeField]
    Color platformActivatedColor;
    SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        if (platformActivatedColor.a == 0) platformActivatedColor = spriteRenderer.color;
    }

    void Start() {
        if (runOnStart == true) StartCoroutine(SetAxisToFollowPath(path));
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (runOnCollision == true && coll.transform.tag == "Player") {
            foreach (GameObject player in players) {
                if (player.GetComponent<GeneralMovementv0>().CheckCollision(GeneralMovementv0.Collision.Bottom) == false
                    || player.GetComponent<GeneralMovementv0>().CollidingWith != transform.gameObject) {

                    return;
                }
            }

            runOnCollision = false;
            StartCoroutine(SetAxisToFollowPath(path));
        }
    }

    Vector2 moveAxis;

    [SerializeField]
    float speed = 30;
	void Update () {
        rigid.velocity = moveAxis * speed;
	}

    [SerializeField]
    Transform[] path;

    [SerializeField]
    float pathDelay;
    [SerializeField]
    TextCountdown countdown;

    [SerializeField]
    float dstMargin = 2;
    bool backwards;
    IEnumerator SetAxisToFollowPath(Transform[] pathPos) {
        if (countdown != null) {
            countdown.StartCountdown(pathDelay);
        }

        while (pathDelay != 0.0f) {
            yield return new WaitForSeconds(1);
            pathDelay--;
        }

        GetComponent<SpriteRenderer>().color = platformActivatedColor;

        int curr = 0;

        while (backwards ? curr > 0 : curr < pathPos.Length) { 
            Vector2 dir = (pathPos[curr].position - transform.position).normalized;
            moveAxis = dir;

            if (Vector3.Distance(transform.position, pathPos[curr].position) < dstMargin) {
                if (backwards == true)
                    curr--;
                else
                    curr++;
            }

            yield return null;
        }

        if (loop == true) {
            backwards = !backwards;

            StartCoroutine(SetAxisToFollowPath(pathPos));
        }
        else {
            moveAxis = Vector2.zero;
        }

    }
}