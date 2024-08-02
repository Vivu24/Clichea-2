using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Serialization;
using static UnityEngine.EventSystems.EventTrigger;

public class CombatManager : MonoBehaviour
{
    [SerializeField] List<GameObject> entities;

    // Prefab del enemigo por defecto, se puede utilizar si no se pasa uno en el método
    [SerializeField] GameObject defaultEnemyPrefab;
    [SerializeField] GameObject blackEnemyPrefab;

    [FormerlySerializedAs("board")] [SerializeField] BoardManager boardManager;

    //Llamar a cada uno de los controladores y caracteristicas a generar antes de empezar el combate
    //En el resto de managers "secundarios" del combate no se llamará al start para evitar problemas de orden
    private void Start()
    {
        boardManager.GenerateBoard();
        CreateEnemies();
    }

    /// <summary>
    /// Creates enemies of one type with a separation depending how much it needs to create
    /// </summary>
    public void CreateEnemies()
    {
        EnemyOnBoard[] enemies = boardManager.getBoardData().enemyPositions;
        for (int i = 0; i < enemies.Length; i++)
        {
            EnemyOnBoard e = enemies[i];
            Cell cell = boardManager.FindCell(e.x, e.z);
            GameObject newEnemy = Instantiate(e.prefab, 
                cell.gameObject.transform.position, 
                Quaternion.identity);
            entities.Add(newEnemy);
            if (!cell.AssignEntity(newEnemy))
            {
                Debug.Log("la casilla está ocupada!");
            }
        }

        ShuffleShiftBar(); // Ordenar la barra de turnos después de crear los enemigos
    }

    /// <summary>
    /// Orders the entities based on their velocity (VEL) to determine the turn order.
    /// </summary>
    public void ShuffleShiftBar()
    {
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
