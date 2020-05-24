using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour {

    private enum Scenes {
        MENU,
        LEVEL_1
    }
    private InputHandler inputManager;

    // Start is called before the first frame update
    void Start() {
        SetSingleton();
        inputManager = FindObjectOfType<InputHandler>();
    }

    // Update is called once per frame
    void Update() {
        LoadFirstSceneOnInput();
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReloadSceneWithDelay(float delay) {
        Invoke("ReloadScene", delay);
    }

    private void LoadFirstSceneOnInput() {
        if(SceneManager.GetActiveScene().buildIndex != (int) Scenes.LEVEL_1) {
            if(inputManager.GetKeyInput("Jump")) {
                SceneManager.LoadScene((int) Scenes.LEVEL_1);
            }
        }
    }

    private void SetSingleton() {
        if(FindObjectsOfType<SceneLoader>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(this);
        }
    }
}
