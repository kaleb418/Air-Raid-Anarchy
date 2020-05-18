using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

    [Header("Movement Factors")]
    [SerializeField] float xMovementFactor;
    [SerializeField] float xMovementLimit;
    [SerializeField] float yMovementFactor;
    [SerializeField] float yMovementLimit;

    [Header("Angle Factors")]
    [SerializeField] float pitchFactor;
    [SerializeField] float yawFactor;
    [SerializeField] float rollFactor;

    private bool shouldProcessInput;
    private InputHandler inputManager;

    // Start is called before the first frame update
    void Start() {
        inputManager = FindObjectOfType<InputHandler>();

        shouldProcessInput = true;
    }

    // Update is called once per frame
    void Update() {
        ProcessInput(inputManager.GetXThrow(), inputManager.GetYThrow());
    }

    // called via SendMessage()
    public void OnPlayerDeath() {
        this.shouldProcessInput = false;
    }

    private void ProcessInput(float xThrow, float yThrow) {
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