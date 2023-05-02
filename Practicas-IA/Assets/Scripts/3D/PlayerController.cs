using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private Transform cam;
    
    private float turnSmoothVelocity;
    float movementSide;
    float movementForward;
    Vector3 direction;
    Vector3 moveDir;


    void Update()
    {
        movementSide = Input.GetAxisRaw("Horizontal");
        movementForward = Input.GetAxisRaw("Vertical");
        //this.transform.Translate(new Vector3(movementSide, 0, movementForward));

        
        direction = new Vector3 (movementSide, 0, movementForward);
        if (direction.magnitude > 0 )
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
    }
}
