using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipDocking : MonoBehaviour
{
    public bool docked;
    private Rigidbody rb;
    private shipcontrols controls;
    public static StationManager currentStation;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        controls = gameObject.GetComponent<shipcontrols>();
    }

    public void HoldShip(bool docked)
    {
        if (docked) 
        {
            rb.velocity = Vector3.zero;
            controls.EngineEnabled(false);
        }
        if (!docked) 
        { controls.EngineEnabled(true); }
    }
}
