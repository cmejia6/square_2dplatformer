using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {
    void Start() {
        if (!isLocalPlayer) {
            transform.GetComponent<RigidController>().enabled = false;
            return;
        }

        //transform.FindChild("camera").gameObject.AddComponent<Camera>();
        Camera camComp = transform.Find("camera").gameObject.AddComponent<Camera>();

        camComp.clearFlags = CameraClearFlags.SolidColor;
        camComp.backgroundColor = Color.red;
        camComp.orthographic = true;
        camComp.orthographicSize = 80;
    }

    [SerializeField]
    Color startColor;
    public override void OnStartLocalPlayer() {
        transform.Find("sprite").GetComponent<SpriteRenderer>().color = startColor;
    }
}