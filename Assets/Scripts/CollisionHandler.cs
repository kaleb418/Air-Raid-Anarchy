using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler: MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    // Start is called before the first frame update
    void Start() {
        
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
        Invoke("ReloadLevel", levelLoadDelay);
    }

    // called via Invoke()
    private void ReloadLevel() {
        SceneManager.LoadScene(1);
    }
}
