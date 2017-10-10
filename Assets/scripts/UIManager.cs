using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    [SerializeField]
    GameObject[] columns;
    int current;

    public void ActivateNextColumn() {
        current++;
        columns[current].SetActive(true);
    }

    public string sceneName;
    public void LoadScene() {
        SceneManager.LoadScene(sceneName);
    }
}