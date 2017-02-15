using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Blob : MonoBehaviour
{

    Rigidbody2D blob;
    bool isOnGround = true;
    public int blobSize = 1;
    public int blobSizeMod = 1;
    public bool active = true;

    void Start()
    {
        blob = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown("w") && isOnGround)
            {
                blob.AddForce(new Vector2(0, 32), ForceMode2D.Impulse);
            }

            if (Input.GetMouseButtonDown(0) && blobSize > 1)
            {

            }
        }
    }

    private void FixedUpdate()
    {
        if (active)
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
        blobSize += amt;
    }

    public void DecreaseSize(int amt)
    {
        Vector3 scale = transform.localScale;
        for (int i = blobSize; i >= blobSize - amt; i--)
        {
            transform.localScale = new Vector3(scale.x - (1 / ((float)i + 3)), scale.y - (1 / ((float)i + 3)), scale.z);
        }
        blobSize -= amt;
    }
}