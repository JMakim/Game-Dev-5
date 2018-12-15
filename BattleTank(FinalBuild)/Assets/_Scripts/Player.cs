using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float rotSpeed = 10;
    public float speed = 2;

    public GameObject shell;
    public Transform bullSpawn;
    public float delay;
    public float nextShot = 0;

    public float Health;
    public float MaxHealth = 100;
    public float Shield;
    public float MaxShield = 100;

    public float dblSpeed;
    public bool moving;
    public bool deathEnd;

    public Slider healthSlider;
    public Slider shieldSlider;

    public GameObject point1;
    public GameObject point2;
    public GameObject g;
    public GameObject fireEffects;
    public GameObject gameOver;
    public GameObject win;

    public AudioSource[] audio;
    public AudioSource idle;
    public AudioSource move;
    public AudioSource cannonFire;
    public AudioSource deathSfx;

    //public Texture2D crosshair;

    // Use this for initialization
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("Genny");
        rb = GetComponent<Rigidbody>();
        Health = 100;
        Shield = 100;
        idle = audio[0];
        move = audio[1];
        cannonFire = audio[2];
        deathSfx = audio[3];

        MaxShield = 100;
        MaxHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = Health;
        shieldSlider.value = Shield;

        Movement();
        fire();
        guide();
        death();

        if(moving && !move.isPlaying && idle.isPlaying)
        {
            idle.Stop();
            move.Play(); 
        }
        if(move.isPlaying&& Input.GetKeyUp(KeyCode.A))
            {
            idle.Play();
            move.Stop();
            moving = false;
        }if(move.isPlaying&& Input.GetKeyUp(KeyCode.D))
            {
            idle.Play();
            move.Stop();
            moving = false;
        }if(move.isPlaying&& Input.GetKeyUp(KeyCode.S))
            {
            idle.Play();
            move.Stop();
            moving = false;
        }if(move.isPlaying&& Input.GetKeyUp(KeyCode.W))
            {
            idle.Play();
            move.Stop();
            moving = false;
        }
        
        if(Health <= 0 && !deathSfx.isPlaying && deathEnd ==false)
        {
            deathSfx.Play();
            deathEnd = true;
        }

        cheat();

    }


    void Movement()
    {
        
        if (Health > 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                moving = true;
                transform.Rotate(Vector3.up * -rotSpeed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                moving = true;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                moving = true;
                transform.Translate(Vector3.forward * -speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                moving = true;
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
           }
        }
    }

    void fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextShot)
            {
                nextShot = Time.time + delay;
                Instantiate(shell, bullSpawn.position, bullSpawn.rotation);
                shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * 4;
                cannonFire.Play();
            }
        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "laserEnemy")
        {

            {
                Health -= 5;
            }

        }
        if(other.tag == "Way6")
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }

        if(other.tag == "Shield")
        {
            Destroy(other.gameObject);
            Shield = MaxShield;
        }

        if (other.tag == "Health")
        {
            Destroy(other.gameObject);
            Health = MaxHealth;
        }

        if(other.tag == "speedDbl")
        {
            dblSpeed = Time.timeScale + 5;
            speed = speed * 2;
            if (Time.timeScale > dblSpeed)
            {
                speed = speed / 2;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EnemyShell")
        {
            if (Shield > 0)
            {
                Shield -= 1;
            }
            else
            {
                Health -= 1;
            }
        }
    }

    void guide()
    {
        
        if (g == null)
        {
            point1.SetActive(false);
            point2.SetActive(true);
        }
    }

    void death()
    {
        if(Health<=0)
        {
            fireEffects.SetActive(true);
            gameOver.SetActive(true);
        }

    }

    void cheat()
    {
        if (Input.GetKeyUp(KeyCode.O))
            Health -= 10;
        if (Input.GetKeyUp(KeyCode.I))
            Health += 10;
        if (Input.GetKeyUp(KeyCode.K))
            Shield -= 10;
        if (Input.GetKeyUp(KeyCode.L))
            Shield += 10;
    }

}
