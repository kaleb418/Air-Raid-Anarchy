using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Ship:MonoBehaviour {

    [SerializeField] float xMovementFactor;
    [SerializeField] float xMovementLimit;
    [SerializeField] float yMovementFactor;
    [SerializeField] float yMovementLimit;

    [SerializeField] float pitchFactor;
    [SerializeField] float yawFactor;
    [SerializeField] float rollFactor;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        MoveShipOnInput();
        RotateShipOnInput();
    }

    private void MoveShipOnInput() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = transform.localPosition.x + (xThrow * Time.deltaTime * xMovementFactor);
        float yOffset = transform.localPosition.y + (yThrow * Time.deltaTime * yMovementFactor);

        transform.localPosition = new Vector3(Mathf.Clamp(xOffset, -xMovementLimit, xMovementLimit), Mathf.Clamp(yOffset, -yMovementLimit, yMovementLimit), transform.localPosition.z);
    }

    private void RotateShipOnInput() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float pitch = transform.localPosition.y * pitchFactor + yThrow * (pitchFactor / 2);
        float yaw = transform.localPosition.x * yawFactor * 1.5f + xThrow * yawFactor;
        float roll = xThrow * pitchFactor * 1.5f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
