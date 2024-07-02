using UnityEngine;
/// <summary>
/// Scriptable que define los atributos de una clase, sus habilidades y etc.
/// Para saber que hace cada atributo, ir al documento de dise�o
/// </summary>
[CreateAssetMenu(fileName = "Job", menuName = "ScriptableObjects/Party/Job", order = 1)]
public class JobData : ScriptableObject
{
    public enum JobType {
        Def, Atk, Supp
    }

    [SerializeField]
    [Tooltip("Vida adicional")]
    public int addtPV;
    [SerializeField]
    [Tooltip("Ataque")]
    public int addtATK;
    [SerializeField]
    [Tooltip("Defensa")]
    public int addtDEF;
    [SerializeField]
    [Tooltip("Poder")]
    public int addtP;
    [SerializeField]
    [Tooltip("Movimiento")]
    public int addtMOV;
    [SerializeField]
    [Tooltip("Velocidad")]
    public int addtVEL;
    [SerializeField]
    [Tooltip("Nombre de la clase")]
    public string CLASSNAME;
    [SerializeField]
    [Tooltip("El tipo principal de la clase")]
    public JobType CLASSTYPE;

    //Tambi�n deber�a tener una estructura de datos con las diferentes habilidades y su nivel para desbloqueo
}
