using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab; //Prefab de la casilla
    [SerializeField] BoardData boardData; //El tablero a construir
    [SerializeField] Vector3 cell00position = Vector3.zero; //La posici�n en la que empezar a construir el board

    static float CELL_SEPARATION = 5.1f;
    Cell[,] _cells; //El array de casillas del tablero.


    /// <summary>
    /// Crea un tablero a partir de los parametros.
    /// </summary>
    /// <param name="xCells">El numero de casillas en el eje x</param>
    /// <param name="zCells">El numero de casillas en el eje z</param>
    public void GenerateBoard()
    {
        int xCells = boardData.xCells;
        int zCells = boardData.zCells;

        _cells = new Cell[xCells, zCells];

        if (xCells <= 0 || zCells <= 0) return;

        // Crear un empty con todas las celdas
        GameObject boardParent = new GameObject("Board");

        for (int i = 0; i < xCells; i++)
        {
            for (int j = 0; j < zCells; j++)
            {
                Cell cell = Instantiate(cellPrefab,
                    new Vector3(cell00position.x + i * CELL_SEPARATION, cell00position.y, cell00position.z + j * CELL_SEPARATION),
                    Quaternion.identity).GetComponent<Cell>();

                // Establecer el padre de la celda recién instanciada
                cell.transform.SetParent(boardParent.transform);

                _cells[i, j] = cell;
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

    public BoardData getBoardData()
    {
        return boardData;
    }

    public Cell FindCell(int x, int y)
    {
        try
        {
            return _cells[x, y];
        }
        catch (Exception e)
        {
            Debug.Log("la casilla buscada no está en el tablero: " + "x = " + x + "y = " + y);
            return _cells[0, 0];
            Debug.Log(e);
            throw;
        }
    }
}
