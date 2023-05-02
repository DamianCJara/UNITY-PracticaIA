using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class IAController : MonoBehaviour
{

    /* NO FUNCIONA !!!!!!!!!!!
     */
    [SerializeField] private float speedMovement;

    [SerializeField] private GameObject point;
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;
    [SerializeField] private GameObject point3;
    [SerializeField] private GameObject point4;
    [SerializeField] private GameObject point5;

    [SerializeField] private int flag;

    void Start()
    {
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 0)
        {
            Movimiento(point);
        }

        else if (flag == 1)
        {
            Movimiento(point1);
        }

        if (flag == 2)
        {
            Movimiento(point2);
        }

        else if (flag == 3)
        {
            Movimiento(point3);
        }

        if (flag == 4)
        {
            Movimiento(point4);
        }

        else if (flag == 5)
        {
            Movimiento(point5);
        }
    }

    void Movimiento(GameObject g)
    {

        Vector3 direction = Vector3.zero; 
        direction = g.transform.position - this.transform.position;

        if (direction.sqrMagnitude >= 0.0001)
        {
            Vector3 directionAndSpeed = direction.normalized * speedMovement * Time.deltaTime;
            this.transform.position += directionAndSpeed;
        }

        if (direction.sqrMagnitude <= 0.001)
        {
            flag += 1;
            //Rotar(direction);
            if (flag == 6)
            {
                flag = 0;
            }
        }
    }

    void Rotar(Vector3 d)
    {
        float angler = Vector3.Angle(this.transform.up, d);
        
        int clockwise = 1;
        if (Cross(this.transform.up, d).z < 0)
        {
            clockwise = -1;
        }
        this.transform.Rotate(0, 0, angler * clockwise);
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;

        return (new Vector3(xMult, yMult, zMult));
    }
}
