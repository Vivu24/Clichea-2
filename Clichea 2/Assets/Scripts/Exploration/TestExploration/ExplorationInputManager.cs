using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationInputManager : MonoBehaviour
{
    #region references
    private ExplorationMovementManagerPablo _myMovement;
    #endregion

    #region parameters
    #endregion

    #region methods
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myMovement = GetComponent<ExplorationMovementManagerPablo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKey("w"))
        {
            _myMovement.SetVerticalInput(1);
        }
        else if (UnityEngine.Input.GetKey("s"))
        {
            _myMovement.SetVerticalInput(-1);
        }
        else
        {
            _myMovement.SetVerticalInput(0);
        }


        if (UnityEngine.Input.GetKey("d"))
        {
            _myMovement.SetHorizontalInput(1);
        }
        else if (UnityEngine.Input.GetKey("a"))
        {
            _myMovement.SetHorizontalInput(-1);
        }
        else
        {
            _myMovement.SetHorizontalInput(0);
        }
    }
}
