using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public GameObject ballPrefab;
    public Vector3 ShotDirction;
	public Renderer rend;
    public bool is_shot = true;
    public float shottime;
	bool is_quick;

	void Start()
	{
		rend = GetComponent<Renderer>();
		is_quick = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (is_shot)
            StartCoroutine(ShotBall(ballPrefab));
    }

    IEnumerator ShotBall(GameObject ballPreb)
    {
        is_shot = false;
        GameObject item = Instantiate(ballPreb, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Rigidbody clone;
        clone = item.GetComponent<Rigidbody>();
        clone.velocity = ShotDirction;
        yield return new WaitForSeconds(shottime);
        is_shot = true;

    }

	IEnumerator TurnRed()
	{
		is_quick = false;
		shottime = 0.5f;
		Color CurrentColor = rend.material.color;
		rend.material.color = new Vector4 (0.50f, 0.50f, 0.50f, 1.00f);
		yield return new WaitForSeconds (0.5f);
		rend.material.color = CurrentColor;
		yield return new WaitForSeconds (0.5f);
		shottime = 1.5f;
		is_quick = true;
	}

	void OnTriggerStay(Collider coll)
	{
		GameObject object_collided_with = coll.gameObject;
		if (object_collided_with.name == this.name && is_quick)
		{
			StartCoroutine(TurnRed ());
		}
	}
		
}
