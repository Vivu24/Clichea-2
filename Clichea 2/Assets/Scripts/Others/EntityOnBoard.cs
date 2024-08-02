using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Define la posición de una entidad en el tablero.
/// </summary>
[System.Serializable]
public struct EntityOnBoard
{
    public int x;
    public int z;
    [Tooltip("Los datos de la entidad")]
    public EntityData entityData;

    public EntityOnBoard(int x, int z, EntityData entityData)
    {
        this.x = x;
        this.z = z;
        this.entityData = entityData;
    }
}