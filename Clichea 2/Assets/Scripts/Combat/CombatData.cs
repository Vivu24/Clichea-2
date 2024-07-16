using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combat", menuName = "ScriptableObjects/Combat/Combat", order = 1)]
public class CombatData : ScriptableObject
{
    [SerializeField]
    public BoardData board;
    [SerializeField]
    public EnemyData[] enemies;
}