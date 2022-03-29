using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    void Start()
    {
        speed = Random.Range(110, 300);


    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * Time.fixedDeltaTime * speed;
    }
}
