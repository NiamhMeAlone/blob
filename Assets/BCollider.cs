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
        if (willPerform && collision.CompareTag("BlobCollider"))
        {
            collision.GetComponent<BCollider>().willPerform = false;
            if (collision.transform.parent.CompareTag("Active"))
            {
                transform.parent.tag = "Active";
            }
            GetComponentInParent<Blob>().IncreaseSize(collision.GetComponentInParent<Blob>().blobSize);
            Destroy(collision.transform.parent.gameObject);
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
