using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    public WheelCollider wheelCollider1, wheelCollider2, wheelCollider3, wheelCollider4;

    public float driveSpeed;
    public float directionSpeed;

    private Vector2 moveInput;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -0.5f, 0);
    }
    private void FixedUpdate()
    {
        float motor = moveInput.y * driveSpeed;
        float steer = moveInput.x * directionSpeed;

        wheelCollider1.motorTorque = motor;
        wheelCollider2.motorTorque = motor;
        wheelCollider3.motorTorque = motor;
        wheelCollider4.motorTorque = motor;

        wheelCollider1.steerAngle = steer;
        wheelCollider2.steerAngle = steer;
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
}
