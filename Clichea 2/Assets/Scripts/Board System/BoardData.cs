using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board", menuName = "ScriptableObjects/Board", order = 1)]
public class BoardData : ScriptableObject
{
    //Datos para la creación de un board.
    [SerializeField]
    public int xCells;
    [SerializeField]    
    public int zCells;
}
