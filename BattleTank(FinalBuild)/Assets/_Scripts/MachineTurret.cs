using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTurret : MonoBehaviour {

    public Transform target;
    public Transform target1;
    public GameObject playerCur;
    public GameObject bullet;
    public Transform bullSpawn;
    public float delay;
    public float nextShot = 0;
    public Player player;
    public float speed;

    public bool TargetOn;
    public bool VipTarget;

    public float Health;


    public AudioSource[] audio;
    public AudioSource fireSfx;
    // Use this for initialization
    void Start()
    {
        delay = 1f;
        fireSfx = audio[0];
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
        if(other.tag == "Player")
        {
            TargetOn = true;
           
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "shell")
        {
            TargetOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
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
                Instantiate(bullet, bullSpawn.position, bullSpawn.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 5;
                fireSfx.Play();
            }
        }
    }
}
