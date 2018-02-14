using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal: MonoBehaviour
{

    public int heal;
    public GameObject enemy;
	public GameObject particle;
    SpriteRenderer sr;
    ShowScore ss;
    public string tagname;

    // Use this for initialization
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (heal <= 0)
        {
            //disappear
            var scorePane = GameObject.Find("/Canvas/NormalPane/Yourscore");
            ss = scorePane.GetComponent<ShowScore>();
            ss.GetScore();
            Destroy(enemy);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        //kill by sword
        if (object_collided_with.tag == tagname)
        {
            StartCoroutine(TurnRed());
            Destroy(object_collided_with);
            
        }

    }


    IEnumerator TurnRed()
    {

        heal -= 1;
		Vector3 particleposition = transform.position - Vector3.forward;
		GameObject item = Instantiate(particle, particleposition, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);

    }

}
