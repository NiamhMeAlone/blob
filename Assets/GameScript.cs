using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    GameObject player;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject paused;
    public GameObject[] doors;
    public GameObject[] buttons;
    public Dictionary<Button, Door> bdDict = new Dictionary<Button, Door>();

    
    public Camera cam;
    void Start ()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        paused.SetActive(false);
        for (int i = 0; i < buttons.Length; i++)
        {
            bdDict.Add(buttons[i].GetComponent<Button>(), doors[i].GetComponent<Door>());
        }
	}
	
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Active");
	}

    public void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        paused.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        paused.SetActive(false);
        player.GetComponent<Blob>().SetTimer(1f);
        Time.timeScale = 1;
    }
}
