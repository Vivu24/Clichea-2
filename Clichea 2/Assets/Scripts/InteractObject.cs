using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private float _interactDistance;

    public float _interactionsCounter;      // Para contar las interacciones con el objeto

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && EstaDentroDelArea())
        {
            RealizarInteraccion();
            _interactionsCounter++;
        }
    }

    private bool EstaDentroDelArea()
    {
        float distanciaAlJugador = Vector2.Distance(transform.position, _player.transform.position);
        return distanciaAlJugador <= _interactDistance;
    }

    private void RealizarInteraccion()
    {
        Debug.Log("Interacción");
       
    }
}
