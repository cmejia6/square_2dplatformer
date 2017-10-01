using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollowPath : GeneralMovementv0 {
    Rigidbody2D rigid;
    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    [SerializeField]
    PathType[] pathTypes;
    int currentPath = 0;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            followPath = true;
            StartCoroutine(SetRigidPath(pathTypes[currentPath]));
        }

        if (followPath == true && pathIsRunning == false && currentPath < pathTypes.Length -1) {
            currentPath++;
            Debug.Log("current path is " + currentPath);
            StartCoroutine(SetRigidPath(pathTypes[currentPath]));
        }
    }

    bool followPath = false;
    private void FixedUpdate() {
        if (followPath == true) {
            //SetRigidPath(pathTypes[0].pathMovement, pathTypes[0].transform.position);
        }
    }

    [SerializeField]
    float moveSpeed = 20;
    bool pathIsRunning;
    IEnumerator SetRigidPath (PathType pathType) {
        pathIsRunning = true;

        switch (pathType.pathMovement) {
            case PathMovement.Move:

            while (Vector2.Distance(transform.position, pathType.transform.position) > 2) {
                Vector2 dir = (pathType.transform.position - transform.position).normalized;
                rigid.velocity = dir * moveSpeed;

                yield return null;
            }

            break;

            case PathMovement.Jump:
            Debug.Log("should be jumping");
            rigid.velocity = new Vector2(pathType.jumpDirection, pathType.jumpForce);

            break;
        }

        rigid.velocity = Vector2.zero;
        Debug.Log("rigid path done");
        pathIsRunning = false;
    }
}
