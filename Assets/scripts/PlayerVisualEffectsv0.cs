using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualEffectsv0 : MonoBehaviour {
    Rigidbody2D rigid;
    RigidController rigidCont;

    GameObject sprite;
    Material mat;
    Color ogMatColor;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        rigidCont = GetComponent<RigidController>();

        sprite = transform.Find("sprite").gameObject;
        mat = sprite.GetComponent<SpriteRenderer>().material;
        ogMatColor = mat.color;
    }

    [SerializeField]
    Color maxSpeedColor;
	void Update () {
		/*if (Mathf.Abs(rigid.velocity.x) > rigidCont.MaxXVelocity - 5) {
            mat.color = maxSpeedColor;
        }
        else {
            mat.color = ogMatColor;
        }*/

	}


}
