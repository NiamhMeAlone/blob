using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void startScene()
    {
        SceneManager.LoadScene("Test");
    }

    public void quitScene()
    {
        Application.Quit();
    }

    public void menuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}