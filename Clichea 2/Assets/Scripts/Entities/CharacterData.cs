using UnityEngine;

/// <summary>
/// Scriptable que define los atributos y características de un personaje
/// El personaje puede ser aliado o enemigo
/// Para saber que hace cada atributo, ir al documento de diseño
/// </summary>
public class CharacterData : EntityData
{
    [SerializeField]
    [Tooltip("Ataque")]
    public int ATK;
    [SerializeField]
    [Tooltip("Defensa")]
    public int DEF;
    [SerializeField]
    [Tooltip("Poder")]
    public int P;
    [SerializeField]
    [Tooltip("Movimiento")]
    public int MOV;
    [SerializeField]
    [Tooltip("Velocidad")]
    public int VEL;
}
