using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEngine.EventSystems.EventTrigger;

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

    /// <summary>
    /// Creates enemies of one type with a separation depending how much it needs to create
    /// </summary>
    /// <param name="numberOfEnemies"></param>
    /// <param name="prefab"></param>
    /// <param name="separation"></param>
    public void CreateEnemies(int numberOfEnemies, GameObject prefab, float separation)
    {
        Debug.Log("CreateEnemies Button Pressed");

        if (prefab == null)
        {
            prefab = defaultEnemyPrefab; // Usa el prefab por defecto si no se pasa uno
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Calcular la posición del nuevo enemigo (HABRA QUE ADAPTARLO A CASILLAS DEL TABLERO)
            Vector3 newPosition = new Vector3(enemySpawnTransform.position.x,
                                                enemySpawnTransform.position.y,
                                                enemySpawnTransform.position.z + i * separation);
            GameObject newEnemy = Instantiate(prefab, newPosition, Quaternion.identity);
            entities.Add(newEnemy);
        }

        ShuffleShiftBar(); // Ordenar la barra de turnos después de crear los enemigos
    }

    /// <summary>
    /// Orders the entities based on their velocity (VEL) to determine the turn order.
    /// </summary>
    public void ShuffleShiftBar()
    {
        Debug.Log("Shuffling Shift Bar (Gracias EDA.....)");

        // Crear una lista temporal para almacenar las entidades ordenadas
        List<GameObject> sortedEntities = new List<GameObject>();

        // Iterar sobre todas las entidades
        foreach (GameObject entity in entities)
        {
            // Obtener el componente Entity para acceder a los datos
            Entity entityComponent = entity.GetComponent<Entity>();
            EntityData data = entityComponent.data;

            // Si la entidad es de tipo CharacterData, obtener su velocidad, de lo contrario usar 0
            int velocity = 0;
            if (data is CharacterData characterData)
            {
                velocity = characterData.VEL;
            }

            // Insertar la entidad en la lista ordenada en la posición correcta según su velocidad
            bool inserted = false;
            for (int i = 0; i < sortedEntities.Count; i++)
            {
                EntityData sortedData = sortedEntities[i].GetComponent<Entity>().data;
                int sortedVelocity = 0;
                if (sortedData is CharacterData sortedCharacterData)
                {
                    sortedVelocity = sortedCharacterData.VEL;
                }

                if (velocity > sortedVelocity)
                {
                    sortedEntities.Insert(i, entity);
                    inserted = true;
                    break;
                }
            }

            if (!inserted)
            {
                sortedEntities.Add(entity);
            }
        }

        // Asignar la lista ordenada a la lista original de entidades
        entities = sortedEntities;

        // Mostrar el orden de turnos
        for (int i = 0; i < entities.Count; i++)
        {
            EntityData data = entities[i].GetComponent<Entity>().data;
            int velocity = 0;
            if (data is CharacterData characterData)
            {
                velocity = characterData.VEL;
            }
            Debug.Log("Turn " + (i + 1) + ": " + data.NAME + " with VEL: " + velocity);
        }
    }


    /// <summary>
    /// Check when its necessary the win condition to end the battle
    /// </summary>
    public void CheckRoundState()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            // Comprobar si han muerto todas las tropas de un lado
        }
    }
}
