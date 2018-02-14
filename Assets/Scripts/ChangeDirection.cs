using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour {

    Rigidbody rb;
    public bool is_ok;
    private Vector3 original_velocity;

    void Start(){
        rb = GetComponent<Rigidbody>();
        is_ok = true;

    }    
	
	// Update is called once per frame
	void Update () {
            if((transform.position.x>5.5f|| transform.position.x < 0.5f)&&is_ok)
            {
            StartCoroutine(ChangeMyDirection());
                
            }

	}

    IEnumerator ChangeMyDirection()
    {
        is_ok = false;
        original_velocity = rb.velocity;
        rb.velocity =- Vector3.forward;
        yield return new WaitForSeconds(2.0f);
        rb.velocity += Vector3.forward;
        rb.velocity = -original_velocity;
        yield return new WaitForSeconds(1.0f);
        is_ok = true;
    }
}
