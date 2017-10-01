using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingBlock : MonoBehaviour {
    Transform countText;
    Rigidbody2D rigid;
    void Start() {
        countText = transform.GetChild(0).GetChild(0);
        rigid = GetComponent<Rigidbody2D>();

        countText.GetComponent<Text>().text = countStart.ToString("0");
    }

    void Update() {
        if (countText.GetComponent<TextCountdown>().CountDone == true) {
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }

    }

    [SerializeField]
    float countStart = 2;
    bool touched;
    void OnCollisionEnter2D(Collision2D coll) {
        if (touched == false && coll.transform.tag == "Player"
            && coll.transform.GetComponent<GeneralMovementv0>().CheckCollision(GeneralMovementv0.Collision.Bottom) == true) {

            countText.GetComponent<TextCountdown>().StartCountdown(countStart);
            touched = true;
        }
    }

    public float CountStart {
        set {
            countStart = value;
        }
    }
}
