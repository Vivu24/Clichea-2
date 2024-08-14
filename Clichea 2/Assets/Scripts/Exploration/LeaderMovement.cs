using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;  // Velocidad de movimiento
    private Rigidbody rb;         // Referencia al propio Rigidbody
    private Vector3 movement;     // Vector de movimiento "actual"

    private void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // CAMBIAR MOVIMIENTO ESTA ASI PROVISIONAL
        // Obtener las entradas de movimiento del usuario
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en la entrada temporal con los getAxis
        movement = new Vector3(moveX, 0, moveZ).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        // Mover al personaje usando físicas como nos ha enseñado luengo en el fixed
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
