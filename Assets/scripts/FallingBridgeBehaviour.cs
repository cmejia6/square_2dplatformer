using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FallingBridgeBehaviour : MonoBehaviour {
    void Awake() {
        this.enabled = false;
    }

    void Start() {
        spawnedBlocks = new List<Rigidbody2D>();
    }

    [SerializeField]
    [Range(0, 100)]
    int bridgeLength;

    [SerializeField]
    Rigidbody2D blockPrefab;

    [SerializeField]
    float blockCountdown = 2;

    List<Rigidbody2D> spawnedBlocks;
    Vector2 lastPos;

    void Update() {

        if (transform.childCount < bridgeLength) {
            Rigidbody2D currentBlock = Instantiate(blockPrefab, transform);
            spawnedBlocks.Add(currentBlock);

            currentBlock.GetComponent<FallingBlock>().CountStart = blockCountdown;
            currentBlock.transform.position = lastPos;
            lastPos = new Vector2(lastPos.x + 16, lastPos.y);
        }
        else if (transform.childCount > bridgeLength) {
            spawnedBlocks[spawnedBlocks.Count - 1].gameObject.SetActive(false);
            spawnedBlocks[spawnedBlocks.Count - 1].transform.SetParent(DeathPit.Instance.transform);
            spawnedBlocks.Remove(spawnedBlocks[spawnedBlocks.Count - 1]);

            lastPos = new Vector2(lastPos.x - 16, lastPos.y);
        }

        if (bridgeLength == 0) {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
                transform.GetChild(i).SetParent(DeathPit.Instance.transform);
            }

            spawnedBlocks = new List<Rigidbody2D>();
            lastPos = transform.position;
        }

    }
}