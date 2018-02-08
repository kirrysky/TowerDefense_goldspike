using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDisappear : MonoBehaviour {

    public float disappearRate = 3f;
    public GameObject itself;
    private float timeRangeOfDisappear;

	void Update () {
        //Disappear at 5 seconds
        timeRangeOfDisappear += Time.deltaTime;
        if (timeRangeOfDisappear >= disappearRate)
        {
            Destroy(itself);
        }

    }
}
