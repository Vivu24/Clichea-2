using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{

    [SerializeField] GameObject _player;
    [SerializeField] private float _interactDistance;

    private Vector2 _playerPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && EstaDentroDelArea())
        {
            RealizarInteraccion();
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
