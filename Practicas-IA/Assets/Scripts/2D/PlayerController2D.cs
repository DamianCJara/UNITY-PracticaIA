using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotation;

    void Update()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        verticalMovement *= Time.deltaTime * speedMovement;

        float horizontalRotation = Input.GetAxisRaw("Horizontal");
        horizontalRotation *= Time.deltaTime * speedRotation;

        Move(verticalMovement);
        Rotation(horizontalRotation);
    }

    void Move(float move)
    {
        this.transform.Translate(0, move, 0);
    }

    void Rotation(float rotate)
    {
        this.transform.Rotate(0, 0, -rotate);
    }
}
