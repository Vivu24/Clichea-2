using UnityEngine;

/// <summary>
/// Define un personaje jugable de la party, por lo que además de todos los atributos de Character, tiene otros exclusivos de los personajes jugables.
/// </summary>
[CreateAssetMenu(fileName = "Ally", menuName = "ScriptableObjects/Entities/Ally", order = 1)]
public class AllyData : CharacterData
{
    [SerializeField]
    [Tooltip("Vida actual")]
    public int currentPV;
    [SerializeField]
    [Tooltip("La clase asignada al personaje")]
    public JobData CLASS;
}
