using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable que define los atributoss y características de un personaje
/// Para saber que hace cada atributo, ir al documento de diseño
/// </summary>
[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Party/Character", order = 1)]
public class Character : ScriptableObject
{
    [SerializeField]
    [Tooltip("Vida total")]
    public int totalPV;
    [SerializeField]
    [Tooltip("Vida actual")]
    public int actualPV;
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
    [SerializeField]
    [Tooltip("Nombre")]
    public string NAME;
}
