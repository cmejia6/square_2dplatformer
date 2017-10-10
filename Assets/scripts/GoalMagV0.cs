using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalMagV0 : MonoBehaviour {
    [SerializeField]
    int amountOfPlayerToWin = 1;
    [SerializeField]
    int amntOfPlyersTriggered;
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Player") {
            StartCoroutine(AttractObj(coll.gameObject));
        }
    }

    IEnumerator AttractObj(GameObject coll) {
        coll.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        while (coll.transform.position != transform.position) {
            coll.transform.position = Vector2.MoveTowards(coll.transform.position, transform.position, 15 * Time.deltaTime);

            yield return null;
        }

        amntOfPlyersTriggered++;
        
        if (amntOfPlyersTriggered == amountOfPlayerToWin) {
            Camera.main.enabled = false;
            Debug.Log("all player made it");
            LevelCompleted();
        }

    }

    void LevelCompleted() {
        //
        SceneManager.LoadScene(0);
    }
}