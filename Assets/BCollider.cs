using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCollider : MonoBehaviour {

    GameObject bCPrefab;
    public bool willPerform = true;

	// Use this for initialization
	void Start ()
    {
        bCPrefab = (GameObject)Resources.Load("BlobCollider");
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale = GetComponentInParent<Transform>().localScale;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Active"))
        {
            collision.gameObject.GetComponent<Blob>().IncreaseSize(transform.GetComponentInParent<Blob>().blobSize);
            Destroy(transform.parent.gameObject);
        }
        if (collision.gameObject.CompareTag("Blob") && gameObject.transform.parent.CompareTag("Blob"))
        {
            if (willPerform)
            {
                collision.gameObject.GetComponentInChildren<BCollider>().willPerform = false;
                gameObject.GetComponent<Blob>().IncreaseSize(collision.transform.GetComponentInParent<Blob>().blobSize);
                Destroy(collision.transform.parent);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blob"))
        {
            Instantiate(bCPrefab, collision.transform.position, collision.transform.rotation, collision.transform);
        }
    }
}
