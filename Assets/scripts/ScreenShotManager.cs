using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotManager : MonoBehaviour {
    int shotNum = 0;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.F4)) {
            ScreenCapture.CaptureScreenshot("C:/Users/Alex/Desktop/screenshots/" + "shot" + shotNum + ".png");
            shotNum++;
        }
    }
}
