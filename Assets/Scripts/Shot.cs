using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public GameObject ballPrefab;
    public Vector3 ShotDirction;
    public bool is_shot = true;
    public float shottime;

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
}
