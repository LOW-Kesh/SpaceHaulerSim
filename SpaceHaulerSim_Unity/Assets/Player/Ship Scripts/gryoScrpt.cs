using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gryoScrpt : MonoBehaviour
{
    private shipcontrols ship;
    private Vector3 shipVel;
    void Start()
    {
        ship = GetComponentInParent<shipcontrols>();
    }

    void FixedUpdate()
    {
        shipVel = ship.Velocity;
        gameObject.transform.up = shipVel;
    }
}
