using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayKeyMovementv0 : RayControllerV0 {
    const float GRAVITY = -8.8f;

    [SerializeField]
    float moveSpeed;
    float horizVelocity;
    private void Update() {
        /*SetVelocity();
        Move(new Vector3(horizVelocity * Time.deltaTime, 0, 0));*/

        Move(new Vector2(KeyboardAxis.x, -2));
    }

    void SetVelocity() {
        float velTarget = KeyboardAxis.x * moveSpeed;
        horizVelocity = Mathf.SmoothDamp(0, 3, ref horizVelocity, 0.3f);
    }

    /*Vector2 Velocity0 {
        get {
            Vector2 vDirection = new Vector2(KeyboardAxis.x * moveSpeed, 0);
            Mathf.SmoothDamp()
            return new Vector2()            
        }
    }*/
}
