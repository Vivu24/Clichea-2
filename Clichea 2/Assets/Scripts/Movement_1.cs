using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement_1 : MonoBehaviour
{
    float dirX;
    float dirZ;

    [SerializeField]
    float speed;

    Transform cam;

    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardRelative = new Vector3(cam.forward.x,0,cam.forward.z)* dirZ;
        Vector3 rightRelative = new Vector3(cam.right.x, 0, cam.right.z) * dirX;

        Vector3 moveDir = (forwardRelative + rightRelative).normalized * speed;

        body.velocity = new Vector3(moveDir.x, body.velocity.y, moveDir.z);

        print(moveDir);
    }

    public void Move(InputAction.CallbackContext callback)
    {
        //print("vector move =" + callback.ReadValue<Vector2>());
        dirX = callback.ReadValue<Vector2>().x;
        dirZ = callback.ReadValue<Vector2>().y;
    }
}
