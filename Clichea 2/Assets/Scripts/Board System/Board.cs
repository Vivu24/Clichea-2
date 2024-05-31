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
        GenerateBoard(boardData.width, boardData.height);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GenerateBoard(int width,int height)
    {
        cells = new Cell[width, height];

        if (width <= 0 || height <= 0) return;
  
        for(int i = 0;i < width; i++)
        {
            for(int j = 0;j < height;j++)
            {
                Cell cell = Instantiate(cellPrefab, 
                    new Vector3(cell00position.x + i*cellSeparation,cell00position.y,cell00position.z + j * cellSeparation),
                    Quaternion.identity).GetComponent<Cell>();

                cells[i, j] = cell;
                cell.SetBoard(this);
            }
        }

    }
}
