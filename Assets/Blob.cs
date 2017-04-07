using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Blob : MonoBehaviour
{

    Rigidbody2D blob;
    bool isOnGround = true;
    public int blobSize = 1;
    public float blobSizeMod = 1;
    static ArrayList currentBlobs;
    public GameObject controller;
    bool paused = false;
    float timer;
    float x, y;
    Camera cam;
    GameObject blobPrefab;
    private Animator animator;

    void Start()
    {
        blob = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();
        blobPrefab = (GameObject)Resources.Load("Blob");
        currentBlobs = new ArrayList(GameObject.FindGameObjectsWithTag("Blob"));
        controller = GameObject.FindGameObjectWithTag("Controller");
    }
    
    void Update()
    {
        x = GetComponent<Rigidbody2D>().velocity.x;
        y = GetComponent<Rigidbody2D>().velocity.x;
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
                GameObject nextBlob = (GameObject)currentBlobs[0];
                currentBlobs.Remove(nextBlob);
                currentBlobs.Add(gameObject);
                nextBlob.tag = "Active";
                nextBlob.GetComponent<Blob>().timer = .2f;
                tag = "Blob";
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused)
                {
                    controller.GetComponent<GameScript>().Unpause();
                }
                else
                {
                    controller.GetComponent<GameScript>().Pause();
                }
            }
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (x > 0 && isOnGround)
        {
            animator.SetInteger("State", 1);
        }
        else if(x < 0 && isOnGround)
        {
            animator.SetInteger("State", -1);
        }
        else
        {
            animator.SetInteger("State", 0);
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

    public void SetTimer(float time)
    {
        timer = time;
    }

    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Floor") || c.gameObject.CompareTag("Button"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            if (currentBlobs.Count > 0)
            {
                if (CompareTag("Active"))
                {
                    GameObject nextBlob = (GameObject)currentBlobs[0];
                    currentBlobs.Remove(nextBlob);
                    nextBlob.tag = "Active";
                    nextBlob.GetComponent<Blob>().timer = .2f;
                }
                Destroy(this.gameObject);
            }   
            else
            {
                controller.GetComponent<GameScript>().Lose();
            }
        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Floor") || c.gameObject.CompareTag("Button"))
        {
            isOnGround = false;
        }
    }

    public void IncreaseSize(int amt)
    {
        Vector3 scale = transform.localScale;
        for (int i = blobSize; i < blobSize + amt; i++)
        {
            blobSizeMod = 1 / (float)(i + 3);
            transform.localScale = new Vector3(scale.x + blobSizeMod, scale.y + blobSizeMod, scale.z);
            GetComponent<Rigidbody2D>().mass += blobSizeMod;
            scale = transform.localScale;
        }
        blobSize += amt;
    }

    public void DecreaseSize(int amt)
    {
        if (blobSize > 1) {
            Vector3 scale = transform.localScale;
            for (int i = blobSize; i > blobSize - amt; i--)
            {
                blobSizeMod = 1 / (float)(i + 2);
                transform.localScale = new Vector3(scale.x - blobSizeMod, scale.y - blobSizeMod, scale.z);
                GetComponent<Rigidbody2D>().mass -= blobSizeMod;
                scale = transform.localScale;
            }
            blobSize -= amt;
        }
    }

    private void OnDestroy()
    {
        currentBlobs.Remove(gameObject);
    }
}