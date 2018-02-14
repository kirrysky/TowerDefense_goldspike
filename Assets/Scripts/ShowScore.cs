﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    public GameObject WinPane;
    public GameObject LevelupPane;
    public GameObject buildenemytrigger;
    Text text_component;
    BuildEnemy be;
    public  float your_score;
    public float aim_score;
    // Use this for initialization
    void Start () {
		Screen.SetResolution(1024,768,true);
        text_component = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
            text_component.text = "aim  score: " + aim_score.ToString()+"\n";
            text_component.text += "your score: " + your_score.ToString();
            if(your_score >= aim_score)
            {
                WinPane.SetActive(true);
            }
	}

    public void GetScore()
    {
        your_score += 1.0f;
    }

    public void BuildTower()
    {
        your_score -= 10;
    }

    public float GetRealScore()
    {
        return your_score;
    }

    IEnumerator Levelup()
    {
        LevelupPane.SetActive(true);
        be = buildenemytrigger.GetComponent<BuildEnemy>();
        be.ChangeStartTime();
        yield return new WaitForSeconds(5.0f);
        LevelupPane.SetActive(false);
		yield return new WaitForSeconds(5.0f);
		be.ChangeStartTime2();
    }
}
