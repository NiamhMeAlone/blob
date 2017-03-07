using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private GameObject controller;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller");
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ButtonActivate"))
        {
            controller.GetComponent<GameScript>().bdDict[this].OpenDoor();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ButtonActivate"))
        {
            controller.GetComponent<GameScript>().bdDict[this].CloseDoor();
        }
    }
}