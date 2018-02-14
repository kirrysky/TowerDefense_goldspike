using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {

	bool is_direction;
	bool is_X;
	bool is_Z;
	bool is_C;
	bool all_done;
	Text text_component;
	public GameObject BuildEnemy;
	public GameObject NormalPane;
	public GameObject Player;
	public float disappearRate = 3f;
	public float disappearRate2 = 5f;
	private float timeRangeOfDisappear;
	BuildTower bt;

	void Start(){
		is_X = false;
		is_Z = false;
		is_C = false;
		is_direction = false;
		all_done = false;
		text_component = GetComponent<Text>();
		text_component.text = "Press ↑↓←→ to move around";
		bt = Player.GetComponent<BuildTower> ();

	}
	// Update is called once per frame
	void Update () {

		timeRangeOfDisappear += Time.deltaTime;
		if (timeRangeOfDisappear >= disappearRate&&is_direction==false && is_X == false && is_C==false && is_Z==false)
		{
			is_direction = true;
			text_component.text = "Good job! \nPress X to build a tower";

		}
		if (Input.GetKeyDown (KeyCode.X) && is_X == false && is_C==false && is_Z==false) {
			is_X = true;
			bt.BuildATower(bt.GetTower());
			text_component.text = "Good job! \nYour tower is shotting.\nPress C to destroy it.";
		}
		if (Input.GetKeyDown (KeyCode.C) && is_X && is_C==false && is_Z==false) {
			is_C = true;
			text_component.text = "Good job! \nYou destroy a tower.\n Press Z to change your color.";
		}
		if (Input.GetKeyDown (KeyCode.Z) && is_X && is_C && is_Z==false) {
			is_Z = true;
			text_component.text = "Good job! \nPress X to build another tower.";
		}
		if (Input.GetKeyDown (KeyCode.X) && is_X && is_Z && is_C) {
			text_component.text = "Don't let enemy get close to you.";
			timeRangeOfDisappear = 0.0f;
			BuildEnemy.SetActive (true);
			NormalPane.SetActive (true);
			all_done = true;
		}
		if (all_done && timeRangeOfDisappear >= disappearRate2) {
			text_component.text = "";
		}
	}
}
