using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float speed = 30;
    public float rotate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float rotate = speed * Input.GetAxis("Mouse X");
        rotate *= Time.deltaTime;
        transform.Rotate(0,0,rotate);


	}


}
