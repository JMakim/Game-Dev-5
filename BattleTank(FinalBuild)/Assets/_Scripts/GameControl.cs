using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject pause;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Pause();
	}

    public void Pause()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
