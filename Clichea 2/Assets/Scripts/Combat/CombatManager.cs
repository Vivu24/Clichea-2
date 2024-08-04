using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Serialization;
using static UnityEngine.EventSystems.EventTrigger;

public class CombatManager : MonoBehaviour
{
    public List<Entity> _entityList;

    // Prefab del enemigo por defecto, se puede utilizar si no se pasa uno en el método
    [SerializeField] GameObject defaultEnemyPrefab;
    [SerializeField] GameObject blackEnemyPrefab;

    [SerializeField] BoardManager boardManager;

    //Llamar a cada uno de los controladores y caracteristicas a generar antes de empezar el combate
    //En el resto de managers "secundarios" del combate no se llamará al start para evitar problemas de orden
    private void Start()
    {
        //Inicialización de variables
        _entityList = new List<Entity>();
        //Construcción de la escena
        boardManager.GenerateBoard();
        CreateEnemies();
    }

    /// <summary>
    /// Creates enemies of one type with a separation depending how much it needs to create
    /// </summary>
    public void CreateEnemies()
    {
        Debug.Log("CreateEnemies");
        EntityOnBoard[] enemiesOnBoard = boardManager.getBoardData().enemyPositions;
        AddEntity(enemiesOnBoard);
        ShuffleShiftBar(); // Ordenar la barra de turnos después de crear los enemigos
    }

    /// <summary>
    /// Orders the entities based on their velocity (VEL) to determine the turn order.
    /// </summary>
    public void ShuffleShiftBar()
    {
        // Crear una lista temporal para almacenar las entidades ordenadas
        List<Entity> sortedEntities = new List<Entity>();

        // Iterar sobre todas las entidades
        foreach (Entity entity in _entityList)
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
                EntityData sortedData = sortedEntities[i].data;
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
        _entityList = sortedEntities;

        // Mostrar el orden de turnos
        for (int i = 0; i < _entityList.Count; i++)
        {
            EntityData data = _entityList[i].data;
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
        for (int i = 0; i < _entityList.Count; i++)
        {
            // Comprobar si han muerto todas las tropas de un lado
        }
    }

    /// <summary>
    /// Instancia y añade al tablero un array de entidades
    /// </summary>
    /// <param name="ents">Las entidades a crear</param>
    private void AddEntity(EntityOnBoard[] ents)
    {
        for (int i = 0; i < ents.Length; i++)
        {
            EntityOnBoard eob = ents[i];
            //Busca la casilla en la que se va a colocar el enemigo
            Cell cell = boardManager.FindCell(eob.x, eob.z);
            //Instancia el enemigo
            GameObject obj = Instantiate(eob.entityData.prefab,
                cell.gameObject.transform.position,
                Quaternion.identity);
            //Añade el componente entity a la lista de entitys y le asigna sus datos.
            Entity entity = obj.GetComponent<Entity>();
            _entityList.Add(entity);
            entity.data = ents[i].entityData;
            if (!cell.AssignEntity(entity))
            {
                Debug.Log("la casilla está ocupada!");
            }
        }
    }
}
