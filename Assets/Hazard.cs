using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    public GameObject lose;

	// Use this for initialization
	void Start () {
        lose.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Blob"))
        {
            lose.SetActive(true);
        }
    }
}
