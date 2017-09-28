using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PathType { MoveDirection, JumpDirection }
public class NPCFollowPath : GeneralMovementv0 {
    Rigidbody2D rigid;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    bool followPath = false;
    private void FixedUpdate() {
        if (followPath == true) {

        }
    }

    void SetRigidPath (PathType pathType) {
        switch (pathType) {
            case pathType:
            //
            break;
        }

    }
}
