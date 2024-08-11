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
    [SerializeField] GameObject defaultAllyPrefab;

    [SerializeField] BoardManager boardManager;

    // Llamar a cada uno de los controladores y caracteristicas a generar antes de empezar el combate
    // En el resto de managers "secundarios" del combate no se llamará al start para evitar problemas de orden
    private void Start()
    {
        // Inicialización de variables
        _entityList = new List<Entity>();
        // Construcción de la escena
        boardManager.GenerateBoard();
        CreateEntities(); // Se encarga de crear tanto enemigos como aliados
    }

    /// <summary>
    /// Crea todas las entidades (aliados y enemigos) del tablero basado en el board data
    /// </summary>
    public void CreateEntities()
    {
        Debug.Log("CreateEntities");

        // Obtener las posiciones de enemigos y aliados desde el BoardManager
        EntityOnBoard[] enemiesOnBoard = boardManager.getBoardData().enemyPositions;
        EntityOnBoard[] alliesOnBoard = boardManager.getBoardData().allyPositions;

        // Añadir entidades de enemigos
        AddEntity(enemiesOnBoard, blackEnemyPrefab);

        // Añadir entidades de aliados
        AddEntity(alliesOnBoard, defaultAllyPrefab);

        // Ordenar la barra de turnos después de crear todas las entidades
        ShuffleShiftBar();
    }

    /// <summary>
    /// Ordena las entidades basandose en su VEL para determinar el orden
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
        /*
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
        */
    }

    /// <summary>
    /// Checkea si se cumple la win condition para acabar el combate
    /// </summary>
    public void CheckRoundState()
    {
        for (int i = 0; i < _entityList.Count; i++)
        {
            // Comprobar si han muerto todas las tropas de un lado
        }
    }

    /// <summary>
    /// Instancia y añade al tablero un array de entidades.
    /// </summary>
    /// <param name="ents">Las entidades a crear.</param>
    /// <param name="prefab">El prefab a instanciar.</param>
    private void AddEntity(EntityOnBoard[] ents, GameObject prefab)
    {
        for (int i = 0; i < ents.Length; i++)
        {
            EntityOnBoard eob = ents[i];
            // Buscar la casilla en la que se va a colocar la entidad
            Cell cell = boardManager.FindCell(eob.x, eob.z);

            // Instanciar la entidad en la posición correspondiente
            GameObject obj = Instantiate(prefab, cell.gameObject.transform.position, Quaternion.identity);

            // Añadir el componente entity a la lista de entidades y asignar sus datos
            Entity entity = obj.GetComponent<Entity>();
            _entityList.Add(entity);
            entity.data = eob.entityData;

            if (!cell.AssignEntity(entity))
            {
                Debug.Log("La casilla está ocupada!");
            }
        }
    }
}
