
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    Text textComp;
    private void Awake() {
        textComp = GetComponent<Text>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            InputDialogue(rawText[0]);
        }
    }

    [SerializeField]
    TextAsset[] rawText;

    int currentLine = 0;
    //paragraph line amount will be one
    void InputDialogue (TextAsset rText) {

        string[] newText = rText.ToString().Split('\n');

        StartCoroutine(IterateText(newText[currentLine]));
    }

    IEnumerator IterateText (string textToIterate) {

        textComp.text = "";
        int a = 0;

        while (a < textToIterate.Length) {
            textComp.text += textToIterate[a];
            yield return new WaitForSeconds(0.05f);
            a++;
        }
    }

}
