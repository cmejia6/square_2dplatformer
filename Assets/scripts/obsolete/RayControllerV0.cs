using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayControllerV0 : GeneralMovementv0 { 
    protected void Move(Vector2 vel) {
        transform.position += new Vector3(vel.x, IsGrounded ? 0 : vel.y);
    }

    bool IsGrounded {
        get {
            //leaves gap on collsion
            RaycastHit2D[] rays = {
                
            //right side
            Physics2D.Raycast(new Vector2(transform.position.x + 8, transform.position.y - 8f), transform.right, 2),

            //bottom side
            Physics2D.Raycast(new Vector2(transform.position.x - 8, transform.position.y-6f), -transform.up, 2),
            Physics2D.Raycast(new Vector2(transform.position.x + 8, transform.position.y-6f), -transform.up, 2)


            };
        
            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    Debug.Log("collider is " + ray.collider);
                    return true;
                }
            }

            return false;
        }
    }

    //for testing purpoes
    /*void Update() {
        Move(new Vector2(KeyboardAxis.x, -2));
    }*/
}
