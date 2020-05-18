using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputHandler: MonoBehaviour {

    private PlayerController playerController;

    private void Awake() {
        SetSingleton();
    }

    // Start is called before the first frame update
    void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update() {

    }

    public bool GetKeyInput(string keyName) {
        return CrossPlatformInputManager.GetButtonDown(keyName);
    }

    public float GetXThrow() {
        return CrossPlatformInputManager.GetAxis("Horizontal");
    }

    public float GetYThrow() {
        return CrossPlatformInputManager.GetAxis("Vertical");
    }

    private void SetSingleton() {
        if(FindObjectsOfType<InputHandler>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(this);
        }
    }
}
