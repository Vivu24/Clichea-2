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

    }

    // Update is called once per frame
    void Update()
    {
        if (shift)
        {
            print("shift presed");
        }
    }
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

    public void ExplorationMap()
    {
        playerInput.SwitchCurrentActionMap("Exploration");
    }

    public void CombatMap()
    {
        playerInput.SwitchCurrentActionMap("Combat");

    }
}
