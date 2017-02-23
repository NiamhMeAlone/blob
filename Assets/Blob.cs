using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Blob : MonoBehaviour
{

    Rigidbody2D blob;
    bool isOnGround = true;
    public int blobSize = 1;
    public int blobSizeMod = 1;
    static ArrayList currentBlobs;
    float timer;
    Camera cam;
    GameObject blobPrefab;

    void Start()
    {
        blob = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        blobPrefab = (GameObject)Resources.Load("Blob");
        currentBlobs = new ArrayList(GameObject.FindGameObjectsWithTag("Blob"));
    }
    
    void Update()
    {
        if (tag == "Active" && timer <= 0)
        {
            if (Input.GetKeyDown("w") && isOnGround)
            {
                blob.AddForce(new Vector2(0, 32), ForceMode2D.Impulse);
            }
            if (Input.GetMouseButtonDown(0) && blobSize > 1)
            {
                Vector2 vector = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                vector.Normalize();
                GameObject newBlob = Instantiate(blobPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
                newBlob.GetComponent<Rigidbody2D>().AddForce(vector * 50, ForceMode2D.Impulse);
                DecreaseSize(1);
                currentBlobs.Add(newBlob);
            }
            if (Input.GetKeyDown(KeyCode.Space) && currentBlobs.Count != 0)
            {
                Debug.Log(currentBlobs.Count);
                GameObject nextBlob = (GameObject)currentBlobs[0];
                currentBlobs.Remove(nextBlob);
                currentBlobs.Add(gameObject);
                nextBlob.tag = "Active";
                nextBlob.GetComponent<Blob>().timer = .2f;
                tag = "Blob";
            }
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (tag == "Active")
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

    private void OnDestroy()
    {
        currentBlobs.Remove(gameObject);
    }
}