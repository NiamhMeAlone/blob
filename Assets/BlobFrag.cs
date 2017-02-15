﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobFrag : MonoBehaviour {

    public int size = 1;
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gO;
        if (collision.gameObject.CompareTag("Blob"))
        {
            gO = collision.gameObject;
            Blob player = gO.GetComponent<Blob>();
            player.IncreaseSize(size);
            Destroy(gameObject, 0f);
        }
    }
}