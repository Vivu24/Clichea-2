using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{

    // REFERENCES to UIs
    [SerializeField] private GameObject BasicUI;
    [SerializeField] private GameObject MovementUI;
    [SerializeField] private GameObject AbilityUI;

    private GameObject currentActiveUI;

    enum UIStates { BASIC, MOVEMENT, ABILITY }

    // Start is called before the first frame update
    void Start()
    {
        currentActiveUI = BasicUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Actualiza toda la UI del modo combate cuando sea necesario
    /// </summary>
    public void UpdateUICombat()
    {
        
    }

    /// <summary>
    /// Actualiza el etado visual de las entidades que hay en el tablero
    /// </summary>
    public void UpdateVisuals()
    {

    }

    /// <summary>
    /// Se llama al principio del combate para crear las barras de vida de todas las entidades
    /// </summary>
    public void CreateHealthBars()
    {

    }

    /// <summary>
    /// Se encarga de cambiar durante el combate las barras de las entidades
    /// </summary>
    public void UpdateHealthBars()
    {

    }

    /// <summary>
    /// La UI "Normal" donde se puede seleccionar que realizar en el turno
    /// </summary>
    public void ChangeToBasicUI()
    {
        changeCurrentActiveUI(BasicUI);
    }

    /// <summary>
    /// Cambio al modo Movimiento que nos permitira seleccionar hasta que casilla mover al jugador
    /// </summary>
    public void ChangeToMovementUI()
    {
        changeCurrentActiveUI(MovementUI);
    }

    /// <summary>
    /// Cambia al modo Abilidad que nos permitira elegir que habilidad realizar en el combate
    /// </summary>
    public void ChangeToAbilityUI()
    {
        changeCurrentActiveUI(AbilityUI);
    }

    /// <summary>
    /// Recibe como parametro el modo de UI al que se quiere cambiar y lo reemplaza por el que habia previamente
    /// como el currentUI activo
    /// </summary>
    /// <param name="currentUI"></param>
    public void changeCurrentActiveUI(GameObject currentUI)
    {
        currentActiveUI.SetActive(false);
        currentActiveUI = null;
        currentActiveUI = currentUI;
        currentActiveUI.SetActive(true);
    }
}
