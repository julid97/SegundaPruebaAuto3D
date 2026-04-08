using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    public WheelCollider wheelCollider1, wheelCollider2, wheelCollider3, wheelCollider4;

    public Transform wheelMesh1, wheelMesh2, wheelMesh3, wheelMesh4;

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

    private void Update()
    {
        UpdateWheelMesh(wheelCollider1, wheelMesh1);
        UpdateWheelMesh(wheelCollider2, wheelMesh2);
        UpdateWheelMesh(wheelCollider3, wheelMesh3);
        UpdateWheelMesh(wheelCollider4, wheelMesh4);
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }
    private void UpdateWheelMesh(WheelCollider col, Transform mesh)
    {
        Vector3 pos;

        Quaternion rot;

        col.GetWorldPose(out pos, out rot);

        mesh.position = pos;

        mesh.rotation = rot;
    }
}
