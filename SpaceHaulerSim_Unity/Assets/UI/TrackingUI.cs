using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingUI : MonoBehaviour
{
    public static TrackingUI trackingUI;

    public Vector3 trackingObj;
    public GameObject trackerUI;

    public Vector3 objectiveMarker;
    public GameObject objectiveMarkerUI;

    private void Start()
    {
        trackingUI = this;
        trackerUI.SetActive(false);
        objectiveMarkerUI.SetActive(false);
    }

    void Update()
    {
        if (trackingObj != Vector3.zero)
        {
            trackerUI.SetActive(true);
            trackerUI.transform.position = Camera.main.WorldToScreenPoint(trackingObj);
        }
        else if (trackingObj == Vector3.zero)
        {
            trackerUI.SetActive(false);
        }

        if (objectiveMarker != Vector3.zero)
        {
            objectiveMarkerUI.SetActive(true);
        }
        else if (objectiveMarker == Vector3.zero)
        {
            objectiveMarkerUI.SetActive(false);
        }
    }
}
