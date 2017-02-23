using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

    GameObject player;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject[] frags;
    public Blob[] blobs;
    
    public Camera cam;
    void Start ()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        frags = GameObject.FindGameObjectsWithTag("BlobFrag");
        blobs = FindObjectsOfType<Blob>();
	}
	
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Active");
        if(player.GetComponent<Blob>().blobSize == frags.Length + blobs.Length)
        {
            Win();
        }
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
}
