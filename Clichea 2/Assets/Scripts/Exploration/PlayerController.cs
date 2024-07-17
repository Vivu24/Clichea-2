using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region parameters
    private Vector3 movementDir_;

    [SerializeField]
    private float movementSpeed_;

    private float verticalSpeed_;
    #endregion

    #region references
    private CharacterController myCharControl_;

    private Transform myTr_;
    #endregion

    #region methods
    public void setDirection(Vector3 dir)
    {
        movementDir_ = dir.normalized;
    }
    #endregion

    void Start()
    {
        myTr_ = GetComponent<Transform>();
        myCharControl_ = GetComponent<CharacterController>();
        movementDir_ = new Vector3(0, 0, 0);
        GameManager.Instance.gameObject.GetComponent<ExplorationMovementManager>().RegisterPlayer(this);
    }

    void Update()
    {
        movementDir_.y = 0;
        if (movementDir_ != Vector3.zero)
        {
            myTr_.forward = movementDir_.normalized;
        }
        if (!myCharControl_.isGrounded)
        {
            verticalSpeed_ += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalSpeed_ = 0;
        }
        movementDir_.y = verticalSpeed_;
        myCharControl_.Move(movementDir_ * movementSpeed_ * Time.deltaTime);
    }

    void MoverJugador()
    {
        /*float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        transform.Translate( velocidad * Time.deltaTime * movimiento );*/
    }
}
