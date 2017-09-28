using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSprite : MonoBehaviour {
    void Start() {
        StartCoroutine(Blinking());
    }

    [SerializeField]
    float timeInterval = 0.5f;
    bool canBlink;
    IEnumerator Blinking() {
        while (true) {
            yield return new WaitForSeconds(timeInterval);
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
    }

    public bool CanBlink {
        set {
            canBlink = value;
        }
    }
   
}
