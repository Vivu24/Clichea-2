using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;        // El transform del l�der a seguir
    [SerializeField] private Vector3 offset;          // Desplazamiento desde el l�der
    [SerializeField] private float smoothSpeed = 0.125f;  // Velocidad de suavizado para el movimiento de la c�mara

    private Vector3 velocity = Vector3.zero;  // Velocidad actual de la interpolaci�n

    void LateUpdate()
    {
        // Posici�n deseada de la c�mara basada en la posici�n del objetivo y el desplazamiento
        Vector3 desiredPosition = target.position + offset;

        // Interpolaci�n suave entre la posici�n actual de la c�mara y la deseada
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

        // Asegura que la c�mara siempre mira hacia el objetivo
        transform.LookAt(target);
    }
}



