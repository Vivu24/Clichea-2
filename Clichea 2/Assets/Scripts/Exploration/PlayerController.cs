using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Input Temporal hasta tener el sistema

    public float velocidad = 5f; // Velocidad de movimiento del jugador

    void Update()
    {
        MoverJugador();
    }

    void MoverJugador()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        transform.Translate( velocidad * Time.deltaTime * movimiento );
    }
}
