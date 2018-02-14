using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Inspector Fields
    public float movement_speed;
    public Vector3 current_input;

    Rigidbody rb;
    //Transform tf;

    private float correct_position_x;
    private float correct_position_z;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //tf = GetComponent<Transform>();
        current_input = -Vector3.forward;
    }

    void Update()
    {
        rb.velocity = current_input * movement_speed;
    }

}


