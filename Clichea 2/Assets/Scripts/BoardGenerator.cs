using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject cellPrefab;

    [SerializeField]
    float cellSeparation = 1f;

    [SerializeField]
    Vector3 cell00position = Vector3.zero;

    void GenerateBoard(int widht,int height)
    {
        if(widht <= 0 || height <= 0) return;
  
        for(int i = 0;i < widht; i++)
        {
            for(int j = 0;j < height;j++)
            {
                GameObject cell = Instantiate(cellPrefab, 
                    new Vector3(cell00position.x + i*cellSeparation,cell00position.y,cell00position.z + j * cellSeparation),
                    Quaternion.identity);


                Cell cellCmp = cell.GetComponent<Cell>();
                cellCmp.setPos(i, j);
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
