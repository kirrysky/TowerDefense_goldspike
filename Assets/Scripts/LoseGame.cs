using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour {

    public GameObject GameOverPane;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Use this for initialization
    void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        //kill by sword
        if (object_collided_with.tag == "Enemy")
        {
            GameOverPane.SetActive(true);
        }

    }
}
