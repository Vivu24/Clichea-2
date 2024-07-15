using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] List<GameObject> entities;

    // Prefab del enemigo por defecto, se puede utilizar si no se pasa uno en el método
    [SerializeField] GameObject defaultEnemyPrefab;
    [SerializeField] GameObject blackEnemyPrefab;

    [SerializeField] Transform enemySpawnTransform;

    public void Create3BlackEnemies()
    {
        CreateEnemies(3, blackEnemyPrefab, 2.0f);
    }

    // Creates enemies of one type with a separation depending how much it needs to create
    public void CreateEnemies(int numberOfEnemies, GameObject prefab, float separation)
    {
        Debug.Log("CreateEnemies Button Pressed");

        if (prefab == null)
        {
            prefab = defaultEnemyPrefab; // Usa el prefab por defecto si no se pasa uno
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Calcular la posición del nuevo enemigo
            Vector3 newPosition = new Vector3(enemySpawnTransform.position.x, 
                                                enemySpawnTransform.position.y, 
                                                enemySpawnTransform.position.z + i * separation);
            GameObject newEnemy = Instantiate(prefab, newPosition, Quaternion.identity);
            entities.Add(newEnemy);
        }
    }
}
