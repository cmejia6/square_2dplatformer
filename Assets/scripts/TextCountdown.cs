using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCountdown : MonoBehaviour {
    Text txt;
    void Start() {
        txt = GetComponent<Text>();
    }

    public void StartCountdown(float from) {
        StartCoroutine(Countdown(from));
    }

    [SerializeField]
    AudioClip countSound;
    [SerializeField]
    AudioClip finalCountSound;

    bool countDone;
    IEnumerator Countdown(float t) {
        float count = t;

        while (txt.text != "0") {
            txt.text = count.ToString();

            if (countSound != null) {
                AudioSource aud = GetComponent<AudioSource>();
                if (count == 0) {
                    aud.clip = finalCountSound;
                }
                else {
                    aud.clip = countSound;
                }

                aud.Play();
            }

            yield return new WaitForSeconds(1);
            count--;
        }

        countDone = true;
        yield return null;
        countDone = false;
    }

    public bool CountDone {
        get {
            return countDone;
        }
    }

}
