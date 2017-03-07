using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour {

    private GameObject controller;

    void Start ()
    {
        controller = GameObject.FindGameObjectWithTag("Controller");
    }

    void Update ()
    {

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Blob") || c.gameObject.CompareTag("Active"))
        {
            controller.GetComponent<GameScript>().Win();
        }
    }
}
