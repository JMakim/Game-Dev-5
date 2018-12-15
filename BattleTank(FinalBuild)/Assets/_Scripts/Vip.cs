using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vip : MonoBehaviour {

    public float speed;
    public bool Movment;
    public bool waypoint;
    public bool waypoint2;
    public bool waypoint3;
    public bool waypoint4;
    public bool waypoint5;
    public bool waypoint6;

    public Transform target;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;

    public GameObject win;

	// Use this for initialization
	void Start () {
        speed = 0.5f;
        Movment = true;
        
    }

    // Update is called once per frame
    void Update() {

        float step = speed * Time.deltaTime;
        if (Movment)
        { 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        Vector3 targetDir = target.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
        }

        if (waypoint)
            target = target1;
        if (waypoint2)
            target = target2;
        if (waypoint3)
            target = target3;
        if (waypoint4)
            target = target4;
        if (waypoint5)
            target = target5;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Way1")
            waypoint = true;
        if (other.tag == "Way2")
        {
            waypoint = false;
            waypoint2 = true;
        }          
        if (other.tag == "Way3")
        {
            waypoint2 = false;
            waypoint3 = true;
        }
        if (other.tag == "Way4")
        {
            waypoint3 = false;
            waypoint4 = true;
        }
        if (other.tag == "Way5")
        {
            waypoint4 = false;
            waypoint5 = true;
        }
        if (other.tag == "Way6")
        {
            Destroy(this);
        }

    }

}


