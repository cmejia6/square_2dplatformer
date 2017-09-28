using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralGameManager : MonoBehaviour {
    public static GeneralGameManager Instance { get; set; }
    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            RestartLevel();
        }
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
