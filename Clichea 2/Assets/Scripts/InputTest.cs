using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputTest : MonoBehaviour
{
    //player input(asigned in the inspector)
    [SerializeField]
    PlayerInput playerInput;

    private bool shift= false;

    // Start is called before the first frame update
    void Start()
    {
        ExplorationMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (shift)
        {
            print("shift presed");
        }
    }

    #region Exploration map

    //wasd
    public void Move(InputAction.CallbackContext callback)
    {
        print("vector move =" + callback.ReadValue<Vector2>());
    }
    //space
    public void Jump(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            print("jump");
        }
    }
    //e
    public void Interact(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            print("interact");

        }
    }
    //x
    public void EnergyAure(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            print("EnergyAure");
        }
    }
    //shift
    public void Shift(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            shift = true;
        }
        else if(callback.canceled)
        {
            shift = false;
        }
    }
    #endregion

    #region CombatMap

    //actualmente estan asignadas las teclas q,w,e,r para las skills 1,2,3,4 respectivamente

    public void Skill_1(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            print("skill_1 pressed");
        }
    }
    public void Skill_2(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            print("skill_2 pressed");
        }
    }
    public void Skill_3(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            print("skill_3 pressed");
        }
    }
    public void Skill_4(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            print("skill_4 pressed");
        }
    }


    #endregion

    #region Switch Maps

    //estas funciones se llamaran desde fuera cuando toque(de momento botones)

    public void ExplorationMap()
    {
        playerInput.SwitchCurrentActionMap("Exploration");
        print("mapa de acciones actual: exploration");
    }

    public void CombatMap()
    {
        playerInput.SwitchCurrentActionMap("Combat");
        print("mapa de acciones actual: combat");


    }

    #endregion

}
