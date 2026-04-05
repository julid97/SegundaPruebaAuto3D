using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRb;

    Vector3 _moveInput = Vector3.zero;
    public float _speed = 20f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(_moveInput * _speed);

        //transform.rotation = Quaternion.Slerp(
        //    transform.rotation,
        //    Quaternion.LookRotation(Mouse.current.position.ReadValue()),
        //    Time.deltaTime * _speed
        //);

        
    }

    public void OnMove(InputValue value)
    {
        Vector2 inputVec = value.Get<Vector2>();
        _moveInput = new Vector3(inputVec.x, 0f, inputVec.y);
    }
}
