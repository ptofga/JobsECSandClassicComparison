using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation= Quaternion.AngleAxis(Mathf.Sin(Time.timeSinceLevelLoad) * 100, Vector3.up);
        this.transform.Translate(new Vector3(0, Mathf.Sin(Time.timeSinceLevelLoad)/100f,0));
    }
}
