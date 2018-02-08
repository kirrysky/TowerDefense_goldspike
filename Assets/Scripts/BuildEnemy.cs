using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEnemy : MonoBehaviour {

    public GameObject PinkEnemyPrefab;
    public GameObject GreenEnemyPrefab;
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
    }

    Vector3 GetInput()
    {
        Vector3[] directions = { new Vector3(0.5f,1.45f,4.5f), new Vector3(1.5f, 1.45f, 4.5f),new Vector3(2.5f, 1.45f, 4.5f), new Vector3(3.5f, 1.45f, 4.5f)};
        Vector3 direction = directions[Random.Range(0, directions.Length)];
        return direction;
    }

    GameObject GetEnemy()
    {
        GameObject[] enemies = {PinkEnemyPrefab, GreenEnemyPrefab};
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
