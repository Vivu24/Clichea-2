using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public struct EnemyOnBoard
{
    public int x;
    public int z;
    public GameObject prefab;

    public EnemyOnBoard(int x, int z, GameObject prefab)
    {
        this.x = x;
        this.z = z;
        this.prefab = prefab;
    }
}