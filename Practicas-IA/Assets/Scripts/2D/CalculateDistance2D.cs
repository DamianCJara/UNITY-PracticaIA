using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance2D : MonoBehaviour
{
    [SerializeField] GameObject fuel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Distance();
        }
    }

    private void Distance()
    {
        //float distanceV1 = Mathf.Sqrt((Mathf.Pow(fuel.transform.position.x - this.transform.position.x,2))
        //                                + (Mathf.Pow(fuel.transform.position.y - this.transform.position.y,2)));
        //Debug.Log("V1 = The fuel is at: " + distanceV1 + "m");



        Vector2 distance = fuel.transform.position - this.transform.position;
       // Debug.Log("V2 = The fuel is at: " + distance.magnitude + "m");



        float uDistance = Vector2.Distance(fuel.transform.position, this.transform.position);
        Debug.Log("uDistance = The fuel is at: " + uDistance + "m");


        //Esta es mucho mas rapida, ya que no realiza la radicacion de la funcion de pitagoras. 
        //Esta es mas recomendad para cuando tenemos que realizar varias llamadas a este metodo. Es decir,
        //cuando lo tenemos dentro de un loop como puede ser un update.
        Debug.Log("sqrMagnitude = The fuel is at: " + distance.sqrMagnitude + "m");




        //Este esta mal, porque tomo el parametro Z cuando estoy trabajando con X e Y. Cuando trabaje en 3D tengo que usar este
        //tipo de configuracion en el codigo.
        //float distanceV3 = Mathf.Sqrt((Mathf.Pow(fuel.transform.position.x - this.transform.position.x,2))
        //                                + (Mathf.Pow(fuel.transform.position.z - this.transform.position.z,2)));
       // Debug.Log("V3 = The fuel is at: " + distanceV3 + "m");
    }
}
