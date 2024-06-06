using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    GameObject cellPrefab; //Prefab de la casilla
    [SerializeField]
    float cellSeparation = 1f;
    [SerializeField]
    BoardData boardData; //El tablero a construir
    [SerializeField]
    Vector3 cell00position = Vector3.zero; //La posición en la que empezar a construir el board

    Cell[,] cells; //El array de casillas del tablero.

    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard(boardData.xCells, boardData.zCells);
    }

    /// <summary>
    /// Crea un tablero a partir de los parametros.
    /// </summary>
    /// <param name="xCells">El numero de casillas en el eje x</param>
    /// <param name="zCells">El numero de casillas en el eje z</param>
    void GenerateBoard(int xCells,int zCells)
    {
        cells = new Cell[xCells, zCells];

        if (xCells <= 0 || zCells <= 0) return;
  
        for(int i = 0;i < xCells; i++)
        {
            for(int j = 0;j < zCells;j++)
            {
                Cell cell = Instantiate(cellPrefab, 
                    new Vector3(cell00position.x + i*cellSeparation,cell00position.y,cell00position.z + j * cellSeparation),
                    Quaternion.identity).GetComponent<Cell>();

                cells[i, j] = cell;
                cell.SetBoard(this);
                cell.AssignCellState(Cell.CellState.BASE);
            }
        }
    }

    /// <summary>
    /// Muestra las casillas objetivo a partir de una forma y un objetivo en el centro.
    /// </summary>
    /// <param name="target">La casilla en el centro de la forma</param>
    /// <param name="shape">La forma de la seleccion</param>
    /// <param name="state">El estado de casilla a aplicar</param>
    void HintTargetCells(Cell target, ShapeData shape, Cell.CellState state)
    { 
        
    }
}
