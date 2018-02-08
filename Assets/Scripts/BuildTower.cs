using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour {

    public GameObject PinkTower;
    public GameObject GreenTower;
    public Vector3[] TowerPositions;
    public int position_num;
    public int tower_num;
    public bool is_ok;
    Transform tf;
    ShowScore ss;

    void Start()
    {
        tf = GetComponent<Transform>();
        var scorePane = GameObject.Find("/Canvas/NormalPane/Yourscore");
        ss = scorePane.GetComponent<ShowScore>();
        is_ok = true;
        position_num = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (ss.GetRealScore() >= 10.0f && is_ok)
            {
                    ss.BuildTower();
                    BuildATower(GetTower());

            }
            is_ok = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (tower_num == 0)
            {
                tower_num = 1;
            }else
            {
                tower_num = 0;
            }
        }

    }

    public void BuildATower(GameObject Tower)
    {
        GameObject item = Instantiate(Tower, new Vector3(tf.position.x,0.6f, tf.position.z), Quaternion.identity);
        TowerPositions[position_num] = tf.position;
        position_num += 1;
    }

    GameObject GetTower()
    {
        GameObject[] enemies = { PinkTower, GreenTower };
        GameObject enemy = enemies[tower_num];
        return enemy;
    }

    public int GetTowerNum()
    {
        return tower_num;
    }

	void OnTriggerStay(Collider coll)
	{
		GameObject object_collided_with = coll.gameObject;

		//kill by sword
		if (object_collided_with.tag == "tower")
		{
			is_ok = false;

		}

	}

	void OnTriggerExit(Collider coll)
	{
		GameObject object_collided_with = coll.gameObject;

		//kill by sword
		if (object_collided_with.tag == "tower")
		{
			is_ok = true;

		}

	}
}
