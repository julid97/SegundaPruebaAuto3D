using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleCarController : NetworkBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        if (!IsOwner) return;
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;
        // Movimiento hacia adelante/atrás
        float move = moveInput.y * speed * Time.fixedDeltaTime;
        Vector3 movement = transform.forward * move;

        rb.MovePosition(rb.position + movement);

        // Rotación
        float turn = moveInput.x * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }
    public override void OnNetworkSpawn()
    {
        // Solo activamos el PlayerInput si somos el dueño
        if (IsOwner)
        {
            GetComponent<PlayerInput>().enabled = true;
        }
        else
        {
            // Por seguridad, nos aseguramos que esté apagado en los coches de otros
            GetComponent<PlayerInput>().enabled = false;

            // Opcional: Hacer el Rigidbody cinemático para los demás 
            // así no hay conflictos de física locales
           // rb.isKinematic = true;
        }
    }
}