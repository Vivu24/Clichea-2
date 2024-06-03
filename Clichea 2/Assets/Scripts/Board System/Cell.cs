using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gestiona el aspecto y comportamiento de una casilla en el tablero.
/// De forma predeterminada, no tiene nada establecido. Es el Board que lo crea el que debe gestionarlo.
/// </summary>
public class Cell : MonoBehaviour
{
    Board board;

    /// <summary>
    /// Define el estado de la casilla, por ejemplo si es seleccionable, está siendo seleccionada, es inaccesible, etc.
    /// </summary>
    public enum CellState
    {
        UNASIGNED,
        BASE,
        SELECTABLE
    }

    CellState state = CellState.UNASIGNED; //El estado de esta casilla

    [SerializeField]
    Material baseMaterial; //El material mostrado normalmente.
    [SerializeField]
    Material selectableMaterial; //El material mostrado si la casilla se puede seleccionar/es un area de selección.

    /// <summary>
    /// Asigna un nuevo estado a la casilla y realiza todos los cambios necesarios a su aspecto y comportamiento.
    /// </summary>
    /// <param name="state">El estado de casilla que queremos asignar</param>
    public void AssignCellState(CellState state)
    {
        if (this.state != state)
        {
            this.state = state;
            UpdateMaterial();
        }
    }

    /// <summary>
    /// A partir del estado actual de la casilla, aplica un material.
    /// </summary>
    private void UpdateMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        switch (state)
        {
            case CellState.BASE:
                renderer.material = baseMaterial;
                break;
            case CellState.SELECTABLE:
                renderer.material = selectableMaterial;
                break;
        }
    }

    public void SetBoard(Board board)
    {
        this.board = board;
    }
}
