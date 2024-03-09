using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDocking : MonoBehaviour
{
    public bool docked;
    private Rigidbody rb;
    private shipcontrols controls;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
        controls = gameObject.GetComponent<shipcontrols>();
    }

    void FixedUpdate()
    {
        if (docked)
        {
            rb.velocity = Vector3.zero;
            controls.engineLock = true;
        }
        else if (!docked)
        {
            controls.engineLock = false;
        }
    }
}
