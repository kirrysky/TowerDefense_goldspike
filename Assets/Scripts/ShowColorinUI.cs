using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowColorinUI : MonoBehaviour {
    public Color Pink = new Vector4(1.0f, 0.68f, 0.82f, 1.00f);
    public Color Green = new Vector4(0.20f, 0.36f, 0.21f, 1.00f);
    public Color Blue = new Vector4(0.12f, 0.64f, 1.00f, 1.00f);
    public GameObject Player;
    Graphic gp;
    BuildTower bt;
    // Use this for initialization
    void Start () {

        bt = Player.GetComponent<BuildTower>();
        gp = GetComponent<Graphic>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (bt.GetTowerNum())
        {
            case 0:
                gp.color = Pink;
                break;
            case 1:
                gp.color = Green;
                break;
            case 2:
                gp.color = Blue;
                break;
        }

    }
}
