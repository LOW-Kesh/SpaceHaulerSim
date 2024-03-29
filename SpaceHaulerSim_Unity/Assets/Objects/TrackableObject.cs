using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrackableObject : MonoBehaviour
{
    private shipcontrols ship;
    private Rigidbody rb;
    private bool tracking;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tracking = false;
    }

    private void OnMouseDown()
    {
        if (!StateManager.Statemanager.pauseScene)
        {
            if (tracking)
            {
                Debug.Log("Object Untracked: " + gameObject.name);
                ship = shipcontrols.shipControls;
                tracking = false;
                TrackingUI.trackingUI.trackingObj = Vector3.zero;
                ship.isTracking = false;
                ship.trackVel = Vector3.zero;
            }

            else if (!tracking)
            {
                Debug.Log("Object Tracked: " + gameObject.name);
                ship = shipcontrols.shipControls;
                tracking = true;
                TrackingUI.trackingUI.trackingObj = gameObject.transform.position;
                TrackingUI.trackingUI.trackingName = gameObject.name;
                ship.isTracking = true;
                ship.trackVel = rb.velocity;
            }
        }
        
    }
}
