using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private GameObject objective;
    [SerializeField] private float speed;
    private Vector3 direction;
    private void Start()
    {
        //this.transform.Translate(Meta.transform.position);
        //this.transform.Translate(4, 0, 7);
        //this.transform.position = new Vector3(4, this.transform.position.y, 6.40f);

    }

    private void LateUpdate()
    {
        direction = objective.transform.position - this.transform.position;
        this.transform.LookAt(objective.transform.position);

        if (direction.magnitude >= 2)
        {
            Vector3 directionAndSpeed = direction.normalized * speed * Time.deltaTime;
            this.transform.position += directionAndSpeed;
        }
    }
}
