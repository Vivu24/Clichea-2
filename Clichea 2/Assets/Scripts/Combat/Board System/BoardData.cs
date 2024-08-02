using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Board", menuName = "ScriptableObjects/Board/Board", order = 1)]
public class BoardData : ScriptableObject
{
    //Datos para la creaci�n de un board.
    [SerializeField]
    public int xCells;
    [SerializeField]    
    public int zCells;
    [SerializeField]
    public EntityOnBoard[] enemyPositions;

    public EntityOnBoard[] allyPositions;
}