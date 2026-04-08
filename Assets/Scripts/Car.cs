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
        float driveForce = moveInput.y * driveSpeed;
        float turn = moveInput.x * directionSpeed;

        wheelCollider1.motorTorque = driveForce;
        wheelCollider2.motorTorque = driveForce;
        wheelCollider3.motorTorque = driveForce;
        wheelCollider4.motorTorque = driveForce;

        wheelCollider1.steerAngle = turn;
        wheelCollider2.steerAngle = turn;
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
}
