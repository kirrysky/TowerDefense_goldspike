using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour {

    public float movement_speed = 4;
    public Vector3 CurrentPosition;
    public float up_limit;
    public float down_limit;
    public float left_limit;
    public float right_limit;

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
            if((!(tf.position.x <= left_limit && horizontal_input < 0))&&
               (!(tf.position.x >= right_limit && horizontal_input > 0))&&
               (!(tf.position.z <= down_limit && vertical_input < 0))&&
               (!(tf.position.z >= up_limit && vertical_input > 0))) {
                tf.position += new Vector3(horizontal_input, 0.0f, vertical_input);
            }

            if (tf.position != CurrentPosition){
                StartCoroutine(Move());
            }
            CurrentPosition = tf.position;
        }
    }

    IEnumerator Move()
    {
        is_move = false;
        yield return new WaitForSeconds(0.3f);
        is_move = true;
    }

}
