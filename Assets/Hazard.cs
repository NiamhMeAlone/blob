using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    private GameObject controller;

	void Start ()
    {
        controller = GameObject.FindGameObjectWithTag("Controller");
	}
	
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Blob"))
        {
            controller.GetComponent<GameScript>().Lose();
        }
    }
}
