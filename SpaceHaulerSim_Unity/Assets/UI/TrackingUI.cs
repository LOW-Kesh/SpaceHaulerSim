using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackingUI : MonoBehaviour
{
    public static TrackingUI trackingUI;

    public Vector3 trackingObj;
    public string trackingName;
    private TextMeshProUGUI trackerText;
    public GameObject trackerUI;

    public Vector3 objectiveMarker;
    public string objectiveMarkerName;
    private TextMeshProUGUI objectiveMarkerText;
    public GameObject objectiveMarkerUI;

    private void Start()
    {
        trackingUI = this;
        trackerText = trackerUI.GetComponentInChildren<TextMeshProUGUI>();
        trackerUI.SetActive(false);
        objectiveMarkerText = objectiveMarkerUI.GetComponentInChildren<TextMeshProUGUI>();
        objectiveMarkerUI.SetActive(false);
    }

    void Update()
    {
        if (trackingObj != Vector3.zero)
        {
            trackerUI.SetActive(true);
            trackerUI.transform.position = Camera.main.WorldToScreenPoint(trackingObj);
            trackerText.text = trackingName;
        }
        else if (trackingObj == Vector3.zero)
        {
            trackerUI.SetActive(false);
        }

        if (objectiveMarker != Vector3.zero)
        {
            objectiveMarkerUI.SetActive(true);
            objectiveMarkerUI.transform.position = Camera.main.WorldToScreenPoint(objectiveMarker);
            objectiveMarkerText.text = objectiveMarkerName;
        }
        else if (objectiveMarker == Vector3.zero)
        {
            objectiveMarkerUI.SetActive(false);
        }
    }
}
