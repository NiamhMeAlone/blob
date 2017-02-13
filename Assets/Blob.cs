using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Blob : MonoBehaviour
{

    Rigidbody2D blob;
    bool isOnGround = true;
    public int blobSize = 1;
    public int blobSizeMod = 1;

    // Use this for initialization
    void Start()
    {
        blob = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") && isOnGround)
        {
            blob.AddForce(new Vector2(0, 32), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            blob.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey("d"))
        {
            blob.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Floor"))
        {
            isOnGround = false;
        }
    }

    public void IncreaseSize(int amt)
    {
        Vector3 scale = transform.localScale;
        for (int i = blobSize; i < blobSize + amt; i++)
        {
            transform.localScale = new Vector3(scale.x + (1/((float)i + 3)), scale.y + (1/((float)i + 3)), scale.z);
        }
    }
}