using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotation;
    [SerializeField] GameObject fuel;
    [SerializeField] private bool autoPilot;

    private void Start()
    {
        autoPilot = false;
    }

    void Update()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        verticalMovement *= Time.deltaTime * speedMovement;

        float horizontalRotation = Input.GetAxisRaw("Horizontal");
        horizontalRotation *= Time.deltaTime * speedRotation;

        Move(verticalMovement);
        Rotation(horizontalRotation);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Distance();
            CalcAngle();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            autoPilot = !autoPilot;
        }

        if (autoPilot)
        {
            AutoPilot();
        }
    }

    void AutoPilot()
    {
        Vector3 fuelPos = new Vector3(fuel.transform.position.x, fuel.transform.position.y, 0);
        Vector3 tankPos = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        //float uDistances = Vector3.Distance(fuelPos, tankPos);
        Vector3 distance = fuelPos - tankPos;

        if (distance.sqrMagnitude >= 2)
        {
            this.transform.position += distance.normalized * speedMovement * Time.deltaTime;
        }
        else
        {
            autoPilot = false;
        }

            CalcAngle();
    }
    void Move(float move)
    {
        this.transform.Translate(0, move, 0);
    }

    void Rotation(float rotate)
    {
        this.transform.Rotate(0, 0, -rotate);
    }

    private void Distance()
    {
        Vector2 distance = fuel.transform.position - this.transform.position; //Obtengo la direccion y sistancia del objetivo
        float uDistance = Vector2.Distance(fuel.transform.position, this.transform.position); //Otra forma de conseguir la distancia y direccion.
        Debug.Log("sqrMagnitude = The fuel is at: " + distance.sqrMagnitude + "m");
    }

    void CalcAngle()
    {
        Vector3 tankForward = this.transform.up; //Almaceno la direccion del tanque.
        Vector3 fuelDirection = fuel.transform.position - this.transform.position; //Obtengo la distacia

        Debug.DrawRay(this.transform.position, tankForward * 10, Color.green, 5);
        Debug.DrawRay(this.transform.position, fuelDirection, Color.red, 5);

        float dot = tankForward.x * fuelDirection.x + tankForward.y * fuelDirection.y; //Obtengo la orientacion del vectoy resultante
        float angle = Mathf.Acos(dot / (tankForward.magnitude * fuelDirection.magnitude)); //Obtengo el angulo que hay entre estos dos vectores
        float unityAngle = Vector3.Angle(tankForward, fuelDirection); //Obtemgo el angulo de una fomra mas facil

        Debug.Log("The angle is: " + angle * Mathf.Rad2Deg);
        Debug.Log("The Unity angle is: " + Vector3.Angle(tankForward, fuelDirection));


        int clockwise = 1;
        if (Cross(tankForward, fuelDirection).z < 0)
        {
            clockwise = -1;
        }
        //this.transform.Rotate(0, 0, angle * Mathf.Rad2Deg * clockwise);
        this.transform.Rotate(0, 0, unityAngle * clockwise);//Roto al tanque.
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;

        return (new Vector3(xMult, yMult, zMult));
    }
}
