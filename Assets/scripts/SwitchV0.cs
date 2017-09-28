using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchV0 : MonoBehaviour {
    [SerializeField]
    Color activeColor = Color.yellow;

    bool switchActive;

    //trigger for knowing if any switch has been changed
    static bool switchHit;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "block") {

            GetComponent<SpriteRenderer>().color = activeColor;
            StartCoroutine(AttractBlock(coll.gameObject));
        }
    }

    IEnumerator AttractBlock(GameObject block) {
        while ((Vector2)block.transform.position != (Vector2)transform.position) {
            Vector3 switchTargDir = (transform.position - block.transform.position).normalized;

            block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            block.transform.position = Vector2.MoveTowards(block.transform.position, transform.position, 20 * Time.deltaTime);

            yield return null;
        }

        switchHit = true;

        switchActive = true;
        Debug.Log("siwtch active");
        yield return null;

        switchHit = false;

    }

    public static bool SwitchHit {
        get {
            return switchHit;
        }
    }

    public bool SwitchActive {
        get {
            return switchActive;
        }
    }
}
