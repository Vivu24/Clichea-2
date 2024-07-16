using UnityEngine;
/// <summary>
/// Scriptable que define una entidad cualquiera en escena.
/// El propósito de este ScriptableObject es ser heredado por los scripts que finalmente serán creados. Ej. Character, Enemy.
/// </summary>
public class EntityData : ScriptableObject
{
    [SerializeField]
    [Tooltip("Vida total")]
    public int totalPV;
    [SerializeField]
    [Tooltip("Nombre")]
    public string NAME;
    [SerializeField]
    [Tooltip("Prefab")]
    public GameObject prefab;
}
