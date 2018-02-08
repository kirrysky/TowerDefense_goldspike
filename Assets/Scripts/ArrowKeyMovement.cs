using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour {

    public float movement_speed = 4;
    public Vector3 CurrentPosition;

    Transform tf;
    public bool is_move;

    // Use this for initialization
    void Start () {
        tf = GetComponent<Transform>();
        is_move = true;
        CurrentPosition = tf.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (is_move)
        {
            float horizontal_input = Input.GetAxisRaw("Horizontal");
            float vertical_input = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(horizontal_input) > 0.0f)
                vertical_input = 0.0f;
            if((!(tf.position.x <= 0.5 && horizontal_input < 0))&&
               (!(tf.position.x >= 3.5 && horizontal_input > 0))&&
               (!(tf.position.z <= -0.5 && vertical_input < 0))&&
               (!(tf.position.z >= 4.5 && vertical_input > 0))) {
                tf.position += new Vector3(horizontal_input, 0.0f, vertical_input);
            }

            if (tf.position != CurrentPosition){
                StartCoroutine(Move());
            }
            CurrentPosition = tf.position;
        }
        //Move current player
        
        //Vector3 current_input = GetInput();
        //rb.velocity = current_input * movement_speed;


        //make every movement half tile
        //if (current_input.x == 0 && current_input.z == 0)
        //{
        //    correct_position_x = Mathf.Round(tf.position.x * 2);
        //    correct_position_z = Mathf.Round(tf.position.z * 2);
        //    tf.position = new Vector3(correct_position_x / 2, 0.0f, correct_position_z / 2);
       // }
    }

    IEnumerator Move()
    {
        is_move = false;
        yield return new WaitForSeconds(0.3f);
        is_move = true;
    }
}
