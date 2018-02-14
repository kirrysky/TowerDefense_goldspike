using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisappear : MonoBehaviour {

	public float disappearRate = 3.0f;
	public GameObject itself;
	private float timeRangeOfDisappear;


	void Update () {
		timeRangeOfDisappear += Time.deltaTime;

		if (timeRangeOfDisappear >= disappearRate)
		{
			Destroy(itself);
		}
		
	}
}
