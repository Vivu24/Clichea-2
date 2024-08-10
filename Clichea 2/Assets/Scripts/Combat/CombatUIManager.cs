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

    public void ChangeToBasicUI()
    {
        changeCurrentActiveUI(BasicUI);
    }

    public void ChangeToMovementUI()
    {
        changeCurrentActiveUI(MovementUI);
    }

    public void ChangeToAbilityUI()
    {
        changeCurrentActiveUI(AbilityUI);
    }

    public void changeCurrentActiveUI(GameObject currentUI)
    {
        currentActiveUI.SetActive(false);
        currentActiveUI = null;
        currentActiveUI = currentUI;
        currentActiveUI.SetActive(true);
    }

}
