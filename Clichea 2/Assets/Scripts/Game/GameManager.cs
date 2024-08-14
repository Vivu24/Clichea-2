using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Unique allowed instance of GameManager class, self-assigned on Awake (singleton)
    /// </summary>
    static private GameManager _instance;

    /// <summary>
    /// Public accessor so everyone can access the unique instance of the class withoutbeing able to modify it.
    /// </summary>
    static public GameManager Instance
    {
        get { return _instance; }
    }
    #endregion

    #region references
    /// <summary>
    /// Reference to input manager
    /// </summary>
    private ExplorationMovementManagerPablo movementMng_;

    /// <summary>
    /// Public accessor for InputManager so everyone can access it via GameManager without being able to modify it.
    /// </summary>
    public ExplorationMovementManagerPablo MoveMng
    {
        get { return movementMng_; }
    }
    #endregion

    #region methods
    #endregion

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        movementMng_ = GetComponent<ExplorationMovementManagerPablo>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}