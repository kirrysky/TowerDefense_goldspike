using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour {

    public GameObject[] TowerPrefab;
    public int Tower_Sum;
    public int tower_num;
    public int size;
    public bool is_ok;
    Transform tf;
    ShowScore ss;

    void Start()
    {
        tf = GetComponent<Transform>();
        var scorePane = GameObject.Find("/Canvas/NormalPane/Yourscore");
        ss = scorePane.GetComponent<ShowScore>();
        is_ok = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Tower_Sum > 0 && is_ok)
            {
                    BuildATower(GetTower());
            }
            is_ok = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            tower_num = (tower_num + 1) % size;
        }

    }

    public void BuildATower(GameObject Tower)
    {
        GameObject item = Instantiate(Tower, new Vector3(tf.position.x,0.6f, tf.position.z), Quaternion.identity);
    }

    public GameObject GetTower()
    {
        GameObject[] towers = TowerPrefab;
        GameObject tower = towers[tower_num];
        return tower;
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
            if (Input.GetKeyDown(KeyCode.C))
            {
                Destroy(object_collided_with);
                is_ok = true;
            }

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
