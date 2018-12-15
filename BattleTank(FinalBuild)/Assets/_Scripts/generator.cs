using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour {
    public float health;
	// Use this for initialization
	void Start () {
        health = 30;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "shell")
        {
            health -= 10;
            Destroy(collision.gameObject);
        }
    }
}
