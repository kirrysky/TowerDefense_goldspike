using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEnemy : MonoBehaviour {

    public GameObject[] EnemyPrefab;
    public Vector3[] enemies;
    public Vector3 enemy_direction;
    public float movement_speed;
    public bool is_start;
    public float start_time;

    void Start()
    {
        is_start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_start)
        {
            StartCoroutine(StartEnemy());
        }    
    }

    public void BuildAEnemy(GameObject Enemy,Vector3 enemy_position)
    {
        GameObject item = Instantiate(Enemy, enemy_position, Quaternion.identity);
        Rigidbody enemy_rb;
        enemy_rb = item.GetComponent<Rigidbody>();
        enemy_rb.velocity = enemy_direction * movement_speed;
    }

    Vector3 GetInput()
    {
        Vector3[] directions = enemies;
        Vector3 direction = directions[Random.Range(0, directions.Length)];
        return direction;
    }

    GameObject GetEnemy()
    {
        GameObject[] enemies = EnemyPrefab;
        GameObject enemy = enemies[Random.Range(0, enemies.Length)];
        return enemy;
    }

    IEnumerator StartEnemy()
    {
        is_start = false;
        BuildAEnemy(GetEnemy(), GetInput());
        yield return new WaitForSeconds(start_time);
        is_start = true;
    }

    public void ChangeStartTime()
    {
		if (start_time - 1.5f > 0.0f) {
			start_time -= 1.5f;	
		} else {
			start_time = 0.1f;
		}
       
    }

	public void ChangeStartTime2()
	{
		start_time += 1.2f;
	}
}
