using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

    [Header("Movement Factors")]
    [SerializeField] float xMovementFactor;
    [SerializeField] float xMovementLimit;
    [SerializeField] float yMovementFactor;
    [SerializeField] float yMovementLimit;
    [SerializeField] GameObject[] playerBulletParticles;

    [Header("Angle Factors")]
    [SerializeField] float pitchFactor;
    [SerializeField] float yawFactor;
    [SerializeField] float rollFactor;

    private InputHandler inputManager;

    private bool shouldProcessInput;

    // Start is called before the first frame update
    void Start() {
        inputManager = FindObjectOfType<InputHandler>();

        shouldProcessInput = true;
    }

    // Update is called once per frame
    void Update() {
        ProcessMovementInput(inputManager.GetXThrow(), inputManager.GetYThrow());

        ProcessFiringInput(inputManager.GetFireButton());
    }

    // called via SendMessage()
    public void OnPlayerDeath() {
        this.shouldProcessInput = false;
    }

    private void ProcessFiringInput(bool isFiring) {
        if(shouldProcessInput) {
            foreach(GameObject particleSystem in playerBulletParticles) {
                particleSystem.SetActive(isFiring);
            }
        }
    }

    private void ProcessMovementInput(float xThrow, float yThrow) {
        if(this.shouldProcessInput) {
            MoveShipOnInput(xThrow, yThrow);
            RotateShipOnInput(xThrow, yThrow);
        }
    }

    private void MoveShipOnInput(float xThrow, float yThrow) {
        float xOffset = transform.localPosition.x + (xThrow * Time.deltaTime * xMovementFactor);
        float yOffset = transform.localPosition.y + (yThrow * Time.deltaTime * yMovementFactor);

        transform.localPosition = new Vector3(Mathf.Clamp(xOffset, -xMovementLimit, xMovementLimit), Mathf.Clamp(yOffset, -yMovementLimit, yMovementLimit), transform.localPosition.z);
    }

    private void RotateShipOnInput(float xThrow, float yThrow) {
        float pitch = transform.localPosition.y * pitchFactor + yThrow * (pitchFactor / 2);
        float yaw = transform.localPosition.x * yawFactor * 1.5f + xThrow * yawFactor;
        float roll = xThrow * pitchFactor * 1.5f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}