using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuOptions : MonoBehaviour {

    public GameObject controller;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        
	}

    public void startScene()
    {
        SceneManager.LoadScene("TutorialScene");
        Time.timeScale = 1;
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
    }

    public void quitScene()
    {
        Application.Quit();
    }

    public void menuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void unpause()
    {
        controller.GetComponent<GameScript>().Unpause();
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }
}