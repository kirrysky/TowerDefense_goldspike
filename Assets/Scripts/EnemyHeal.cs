using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal: MonoBehaviour
{

    public int heal;
    public GameObject enemy;
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

       // sr.color = new Vector4(1, 0, 0, 1);
        heal -= 1;
        yield return new WaitForSeconds(1.0f);
       // sr.color = new Vector4(1, 1, 1, 1);

    }

}
