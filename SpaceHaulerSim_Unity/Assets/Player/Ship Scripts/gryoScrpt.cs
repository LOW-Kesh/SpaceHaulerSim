using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gryoScrpt : MonoBehaviour
{
    private shipcontrols ship;
    private GameObject shippp;
    private Vector3 shipVel;

    public Camera gyrocam;

    void Awake()
    {
        FindFirstObjectByType<Canvas>().worldCamera = gyrocam;
    }
    void Update()
    {
        ship = shipcontrols.shipControls;
        shipVel = ship.Velocity;
        gameObject.transform.up = shipVel;
    }
}
