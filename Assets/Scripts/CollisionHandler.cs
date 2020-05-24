using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler: MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider collider) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        sceneLoader.ReloadSceneWithDelay(5f);
    }
}
