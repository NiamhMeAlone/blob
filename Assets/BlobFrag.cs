using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobFrag : MonoBehaviour {

    public int size = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gO;
        if (collision.gameObject.CompareTag("Blob"))
        {
            gO = collision.gameObject;
            Blob player = gO.GetComponent<Blob>();
            player.IncreaseSize(size);
            Destroy(gameObject, .05f);
        }
    }
}