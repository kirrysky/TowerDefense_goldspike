using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

	Vector3 current_velocity;
	bool is_ok;

	void Start(){
		is_ok = true;
	}
	private void OnTriggerStay(Collider other)
	{
		GameObject object_collided_with = other.gameObject;

			//need to change to enermy
			if (object_collided_with.tag == "Enemy"&&is_ok)
			{
				StartCoroutine(Gogogo(object_collided_with));          
			}
	}

	IEnumerator Gogogo(GameObject other)
	{
		is_ok = false;
		Rigidbody rb;
		rb = other.GetComponent<Rigidbody> ();
		current_velocity = rb.velocity;
		rb.velocity *= 2;
		yield return new WaitForSeconds(1.0f);
		rb.velocity = current_velocity;
		yield return new WaitForSeconds(2.0f);
		is_ok = true;
	}
}
