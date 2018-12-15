using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBody : MonoBehaviour {
    public float health;

    public MachineTurret sense;
    public GameObject s;
	// Use this for initialization
	void Start () {
        health = 20;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "shell")
        {
            health -= 10;
            sense.TargetOn = true;
        }
    }

}
