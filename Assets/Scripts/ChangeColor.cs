using UnityEngine;
using System.Collections;

public class ChangeColor: MonoBehaviour
{
    public Color Pink = new Vector4(1.0f,0.68f, 0.82f, 1.00f);
    public Color Green = new Vector4(0.20f, 0.36f, 0.21f, 1.00f);
    public Color Blue = new Vector4(0.12f, 0.64f, 1.00f, 1.00f);
    //public float duration = 1.0F;
    public Renderer rend;
    BuildTower bt;
    void Start()
    {
        rend = GetComponent<Renderer>();
        bt = GetComponent<BuildTower>();
    }
    void Update()
    {
        switch (bt.GetTowerNum())
        {
            case 0:
                rend.material.color = Pink;
                break;
            case 1:
                rend.material.color = Green;
                break;
            case 2:
                rend.material.color = Blue;
                break;
        }
        
        //float lerp = Mathf.PingPong(Time.time, duration) / duration;
        //rend.material.color = Color.Lerp(Green, Pink, lerp);
    }
}