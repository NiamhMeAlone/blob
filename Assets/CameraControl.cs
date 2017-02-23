using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Active");
	}
	
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Active");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, transform.position.z);
    }
}
