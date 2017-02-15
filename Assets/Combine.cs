using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale = GetComponentInParent<Transform>().localScale;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlobCollider") && !GetComponentInParent<Blob>().active)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
