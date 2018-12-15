using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Canvas startCanvas;
    public Canvas howCanvas;
    public GameObject mainMenu;
    public GameObject HowMenu;
    public GameObject PauseMenu;

    public AudioSource[] audio;
    public AudioSource menu;
    // Use this for initialization
    void Start()
    {
        menu.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gameStart(string x)
    {
        SceneManager.LoadScene(x);
    }

    public void end()
    {
        Application.Quit();
    }

    public void How()
    {
        mainMenu.SetActive(false);
        HowMenu.SetActive(true);
    }
    public void menuReturn()
    {
        mainMenu.SetActive(true);
        HowMenu.SetActive(false);
    }
    public void PauseReturn()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
