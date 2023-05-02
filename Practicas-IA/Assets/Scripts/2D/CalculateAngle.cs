using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CalculateAngle : MonoBehaviour
{
    [SerializeField] GameObject fuel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CalcAngle();
        }
    }

    void CalcAngle()
    {
        Vector3 tankForward = transform.up;
        Vector3 fuelDirection = fuel.transform.position - this.transform.position;

        Debug.DrawRay(this.transform.position, tankForward * 10, Color.green,5);
        Debug.DrawRay(this.transform.position, fuelDirection, Color.red,5);

        float dot = tankForward.x * fuelDirection.x + tankForward.y * fuelDirection.y;
        float angle = Mathf.Acos(dot / (tankForward.magnitude * fuelDirection.magnitude));

        Debug.Log("The angle is: " + angle * Mathf.Rad2Deg);
        Debug.Log("The Unity angle is: " + Vector3.Angle(tankForward, fuelDirection));

        float unityAngle = Vector3.Angle(tankForward, fuelDirection);

        int clockwise = 1;
        if (Cross(tankForward, fuelDirection).z < 0)
        {
            clockwise = -1;
        }

        this.transform.Rotate(0, 0, angle * Mathf.Rad2Deg * clockwise);
        //this.transform.Rotate(0, 0, unityAngle);
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;
        
        return (new Vector3(xMult, yMult, zMult));
    }
}
