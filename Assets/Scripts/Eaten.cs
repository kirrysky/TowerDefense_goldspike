using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eaten : MonoBehaviour {
    public float disappearRate;
    public GameObject itself;
    private float timeRangeOfDisappear;

    void OnTriggerStay(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        //kill by sword
        if (object_collided_with.tag == "Enemy")
        {
            timeRangeOfDisappear += Time.deltaTime;
            if (timeRangeOfDisappear >= disappearRate)
            {
                Destroy(itself);
            }
        }
    }
}
