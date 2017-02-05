using UnityEngine;
using System.Collections;

public class Blob : MonoBehaviour
{

    Rigidbody2D blob;
    bool isOnGround = true;

    // Use this for initialization
    void Start()
    {
        blob = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            blob.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey("d"))
        {
            blob.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("w") && isOnGround)
        {
            blob.AddForce(new Vector2(0, 32), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Floor")
        {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Floor")
        {
            isOnGround = false;
        }
    }
}