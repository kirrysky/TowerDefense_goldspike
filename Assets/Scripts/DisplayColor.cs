using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayColor : MonoBehaviour {

    public GameObject Player;
    Text text_component;
    BuildTower bt;
    int tower_num;
    // Use this for initialization
    void Start()
    {
        text_component = GetComponent<Text>();
        bt = Player.GetComponent<BuildTower>();
    }

    // Update is called once per frame
    void Update()
    {
        tower_num=bt.GetTowerNum();
        if (tower_num==0)
        {
            text_component.text = "current color:pink";
        }
        else
        {
            text_component.text = "current color:green";
        }
    }
}
