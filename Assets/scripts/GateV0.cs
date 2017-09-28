using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateV0 : MonoBehaviour {
    [SerializeField]
    SwitchV0[] switchesToCheck;

    void Update() {
        if (SwitchV0.SwitchHit == true) {
            for (int i = 0; i < switchesToCheck.Length; i++) {

                if (switchesToCheck[i].SwitchActive == false)
                    return;

            }

            OpenGate();
        }
    }

    //open self
    void OpenGate() {
        Destroy(gameObject);
    }
}
