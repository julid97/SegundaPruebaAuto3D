using UnityEngine;

public class Wheel : MonoBehaviour
{
    public WheelCollider wheel;     // Reference to the WheelCollider
    public Transform wheelMesh;     // Visual wheel mesh
    public bool wheelTurn;          // Is this a front wheel?

    void Update()
    {
        // Get position and rotation from collider
        Vector3 pos;
        Quaternion rot;
        wheel.GetWorldPose(out pos, out rot);

        // Apply position
        wheelMesh.position = pos;

        // Apply rotation
        wheelMesh.rotation = rot;
    }
}