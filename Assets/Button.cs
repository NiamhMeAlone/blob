using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (GetComponent<Collider2D>().OverlapPoint(mousePos) && Input.GetMouseButtonDown(0))
        {
            if (tag == "start")
            {
                SceneManager.LoadScene("Test");
            }

            if (tag == "quit")
            {
                Application.Quit();
            }
        }
	}
}
