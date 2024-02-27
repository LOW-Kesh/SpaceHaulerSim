using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackableObject : MonoBehaviour
{
    private shipcontrols ship;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Object Tracked: " + gameObject.name);
        ship = GameObject.FindGameObjectWithTag("Player").GetComponent<shipcontrols>();
        ship.isTracking = true;
        ship.trackVel = rb.velocity;
    }
}
