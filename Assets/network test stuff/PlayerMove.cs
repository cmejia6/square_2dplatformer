using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour {
    public GameObject bulletPrefab;

    public override void OnStartLocalPlayer() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void Update() {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, z,0);

        if (Input.GetKeyDown(KeyCode.Space)) {
            CmdFire();
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            CmdWrite("go fuck urself");
        }
    }

    [Command]
    void CmdFire() {
        // create the bullet object from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position - transform.up * 14,
            Quaternion.identity);

        // make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody2D>().velocity = -transform.up * 40;

        NetworkServer.Spawn(bullet);

        // make bullet disappear after 2 seconds
        Destroy(bullet, 5.0f);
    }

    [SerializeField]
    Text text;

    [Command]
    void CmdWrite(string s) {
        var newTxt = Instantiate(text, Vector2.zero, Quaternion.identity);
        newTxt.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform);

        newTxt.text = s;

        NetworkServer.Spawn(newTxt.gameObject);
    }
}