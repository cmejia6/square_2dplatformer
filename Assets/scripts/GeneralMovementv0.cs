using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovementv0 : MonoBehaviour {
    [SerializeField]
    bool p2Local;
    protected Vector2 KeyboardAxis {
        get {
            if (p2Local == true) {
                return new Vector2(Input.GetAxisRaw("h1"), Input.GetAxisRaw("v1"));
            }

            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }

    public enum Collision {
        Left,
        Right,
        Bottom,
        Top
    }

    GameObject collidingWith;
    RaycastHit2D[] rays;
    float collRad = 7f;
    public bool CheckCollision(Collision collDir) {
        switch (collDir) {
            case Collision.Left:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x - collRad + 2, transform.position.y + collRad), -transform.right, 2.1f),
                Physics2D.Raycast(new Vector2(transform.position.x - collRad + 2, transform.position.y - collRad), -transform.right, 2.1f)
            };

            Debug.DrawRay(new Vector2(transform.position.x - collRad + 2, transform.position.y + collRad), -transform.right * 2.1f);
            Debug.DrawRay(new Vector2(transform.position.x - collRad + 2, transform.position.y - collRad), -transform.right * 2.1f);

            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;
                    return true;
                }
            }

            return false;

            case Collision.Right:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x + collRad - 2, transform.position.y + collRad), transform.right, 2.1f),
                Physics2D.Raycast(new Vector2(transform.position.x + collRad - 2, transform.position.y - collRad), transform.right, 2.1f)
            };

            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;
                    return true;
                }
            }

            return false;

            case Collision.Top:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x - collRad, transform.position.y + collRad - 2), transform.up, 2.1f),
                Physics2D.Raycast(new Vector2(transform.position.x + collRad, transform.position.y + collRad - 2), transform.up, 2.1f)
            };


            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;
                    return true;
                }
            }

            return false;

            case Collision.Bottom:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x - collRad, transform.position.y - collRad + 2), -transform.up, 2.1f),
                Physics2D.Raycast(new Vector2(transform.position.x + collRad, transform.position.y - collRad + 2), -transform.up, 2.1f)
            };

            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;

                    return true;
                }
            }

            return false;
        }

        return false;
    }

    protected bool CheckCollision(Collision collDir, float extension) {
        switch (collDir) {
            case Collision.Left:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x - collRad + 2, transform.position.y + collRad), -transform.right, 2.1f + extension),
                Physics2D.Raycast(new Vector2(transform.position.x - collRad + 2, transform.position.y - collRad), -transform.right, 2.1f + extension)
            };

            Debug.DrawRay(new Vector2(transform.position.x - collRad + 2, transform.position.y + collRad), -transform.right * 2.1f);
            Debug.DrawRay(new Vector2(transform.position.x - collRad + 2, transform.position.y - collRad), -transform.right * 2.1f);

            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;

                    return true;
                }
            }

            return false;

            case Collision.Right:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x + collRad - 2, transform.position.y + collRad), transform.right, 2.1f + extension),
                Physics2D.Raycast(new Vector2(transform.position.x + collRad - 2, transform.position.y - collRad), transform.right, 2.1f + extension )
            };

            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;

                    return true;
                }
            }

            return false;

            case Collision.Top:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x - collRad, transform.position.y + collRad - 2), transform.up, 2.1f + extension),
                Physics2D.Raycast(new Vector2(transform.position.x + collRad, transform.position.y + collRad - 2), transform.up, 2.1f + extension)
            };


            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;

                    return true;
                }
            }

            return false;

            case Collision.Bottom:

            rays = new RaycastHit2D[] {
                Physics2D.Raycast(new Vector2(transform.position.x - collRad, transform.position.y - collRad + 2), -transform.up, 2.1f + extension),
                Physics2D.Raycast(new Vector2(transform.position.x + collRad, transform.position.y - collRad + 2), -transform.up, 2.1f + extension)
            };

            foreach (RaycastHit2D ray in rays) {
                Debug.DrawRay(ray.centroid, -transform.up);

                if (ray.collider != null) {
                    collidingWith = ray.collider.gameObject;

                    return true;
                }
            }

            return false;
        }

        return false;
    }

    protected bool CheckCollisionAt (Vector2 at) {
        return Physics2D.OverlapBox(at, Vector2.one, 0);
    }

    //should be ran right after check collision
    public GameObject CollidingWith {
        get {
            return collidingWith;
        }
    }
}