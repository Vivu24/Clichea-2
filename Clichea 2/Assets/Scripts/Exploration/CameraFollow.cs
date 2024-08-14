using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;        // El transform del líder a seguir
    [SerializeField] private Vector3 offset;          // Desplazamiento desde el líder
    [SerializeField] private float smoothSpeed = 0.125f;  // Velocidad de suavizado para el movimiento de la cámara

    private Vector3 velocity = Vector3.zero;  // Velocidad actual de la interpolación

    void LateUpdate()
    {
        // Posición deseada de la cámara basada en la posición del objetivo y el desplazamiento
        Vector3 desiredPosition = target.position + offset;

        // Interpolación suave entre la posición actual de la cámara y la deseada
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        // Asegura que la cámara siempre mira hacia el objetivo
        transform.LookAt(target);
    }
}



