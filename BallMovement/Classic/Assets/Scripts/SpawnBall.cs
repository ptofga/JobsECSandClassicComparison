using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour {
    public GameObject ball;
    public float Bound = 50;
    public int BallNumer = 1000;
    Text BallNumberText;
    Text FPSText;
	// Use this for initialization
	void Start () {
        BallNumberText = GameObject.Find("BallNumer").GetComponent<Text>();
        FPSText = GameObject.Find("FPS").GetComponent<Text>();

        for (int i=0;i< BallNumer; i++)
        {
            var GO=Instantiate(ball, GetRandomPosition(), Quaternion.identity) as GameObject;
            BallNumberText.text = "Ball Number is " + (i + 1);
        }
	}
	
	// Update is called once per frame
	void Update () {
        FPSText.text = "FPS: "+1 / Time.deltaTime;
	}
    Vector3 GetRandomPosition()
    {
        Vector3 pos;
        float tempx = Bound * (Random.value-0.5f);
        float tempz = Bound * (Random.value-0.5f);
        pos = new Vector3(tempx,0, tempz);
        return pos;
    }
}
