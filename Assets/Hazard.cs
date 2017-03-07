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
}
