using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public Transform target;
    public GameObject playerCur;
    //public GameObject bullet;
    public Transform bullSpawn;
    public float delay;
    public float nextShot = 0;
    public Player player;
    public float speed;
    public float firingTime;
    public bool TargetOn;

    public float Health;
    public GameObject laser;
    public AudioSource[] audio;
    public AudioSource laserSfx;

    // Use this for initialization
    void Start()
    {
        firingTime = 3;
        Health = 20;
        delay = 6f;
        laser.SetActive(false);
        laserSfx = audio[0];
    }
    // Update is called once per frame
    void Update()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerCur = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = p.GetComponent<Player>();


        Track();
        fire();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TargetOn = true;
        }
        if (other.tag == "shell")
        {

            Health -= 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "shell")
        {
            TargetOn = true;
            Health -= 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TargetOn = false;
        }
    }

    void Track()
    {
        if (TargetOn == true)
        {

            Vector3 targetDir = target.position - transform.position;

            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    void fire()
    {
        if (TargetOn)
        {

            if (Time.time > nextShot)
            {
                nextShot = Time.time + delay;
            for (int i = 3; i > 0; i--)
                {
                    laser.SetActive(true);
                    laserSfx.Play();
                }
            }
            else
            {
                laser.SetActive(false);
            }
            
        }
    }
}
