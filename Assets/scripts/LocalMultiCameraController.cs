using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalMultiCameraController : MonoBehaviour {
    Camera cam;
    GameObject[] players;
	void Start () {
        cam = GetComponent<Camera>();
        players = GameObject.FindGameObjectsWithTag("Player");
	}

    enum Bounds {
        Up, Down, Left, Right
    }

    Vector2 GetCamBound(Bounds dir) {
        switch (dir) {
            case Bounds.Up:
            return new Vector2(transform.position.x, transform.position.y + cam.orthographicSize);

            case Bounds.Down:
            return new Vector2(transform.position.x, transform.position.y - cam.orthographicSize);

            case Bounds.Left:
            return new Vector2(transform.position.x - (cam.orthographicSize * cam.aspect), transform.position.y );

            case Bounds.Right:
            return new Vector2(transform.position.x + (cam.orthographicSize * cam.aspect), transform.position.y);
        }

        return Vector2.zero;
    }

    Transform GetClosest(Vector2 fromPos, GameObject[] objects) {
        Transform closest = objects[0].transform;
        for (int i = 0; i < objects.Length; i++) {
            float dist = Vector2.Distance(objects[i].transform.position, fromPos);

            if (dist < Vector2.Distance(closest.position, fromPos)) {
                closest = objects[i].transform;
            }
        }

        return closest;
    }

    float camExpansionSpeed =100;
    float yOffset = 10;
    void Update() {
        transform.position = Vector3.Lerp(players[0].transform.position + new Vector3(0,yOffset), players[1].transform.position + new Vector3(0, yOffset), 0.5f) - new Vector3(0, 0, 10);

        float xPercentage = ((cam.orthographicSize * cam.aspect) * 0.45f);
        float yPercentage = ((cam.orthographicSize* cam.aspect) * 0.35f);

        foreach (GameObject player in players) {
            if (player.transform.position.x > GetCamBound(Bounds.Right).x - xPercentage 
                || player.transform.position.x < GetCamBound(Bounds.Left).x + xPercentage
                || player.transform.position.y > GetCamBound(Bounds.Up).y - yPercentage
                || player.transform.position.y < GetCamBound(Bounds.Down).y + yPercentage) {

                cam.orthographicSize += camExpansionSpeed * Time.deltaTime;
            }
            else if (player.transform.position.x < transform.position.x + xPercentage 
                && player.transform.position.x > transform.position.x - xPercentage
                && player.transform.position.y < transform.position.y + yPercentage
                && player.transform.position.y > transform.position.y - yPercentage) {

                cam.orthographicSize -= camExpansionSpeed * Time.deltaTime;
            }

            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 120, 320);
        }

	}

    void OnDrawGizmos() {
        cam = GetComponent<Camera>();

        Gizmos.color = Color.red;
        // 15 percent
        float xPercentage = ((cam.orthographicSize * cam.aspect) * 0.25f) ;
        Gizmos.DrawLine(new Vector2(GetCamBound(Bounds.Right).x - xPercentage, GetCamBound(Bounds.Down).y), new Vector2(GetCamBound(Bounds.Right).x - xPercentage, GetCamBound(Bounds.Up).y));
        Gizmos.DrawLine(new Vector2(GetCamBound(Bounds.Left).x + xPercentage, GetCamBound(Bounds.Down).y), new Vector2(GetCamBound(Bounds.Left).x + xPercentage, GetCamBound(Bounds.Up).y));

        Gizmos.DrawLine(new Vector2(transform.position.x + xPercentage, GetCamBound(Bounds.Down).y), new Vector2(transform.position.x + xPercentage, GetCamBound(Bounds.Up).y));
        Gizmos.DrawLine(new Vector2(transform.position.x - xPercentage, GetCamBound(Bounds.Down).y), new Vector2(transform.position.x - xPercentage, GetCamBound(Bounds.Up).y));
    }
}
