using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignedOrders : MonoBehaviour
{
    public string title;
    public float amount;
    public string cargo;
    public Vector3 location;
    public string Stationname;
    public int ID;

    //private bool Abandon;

    private bool Track;
    public TextMeshProUGUI orderText;
    public TextMeshProUGUI trackText;

    private void Start()
    {
        orderText.text = title + ": " + "Deliver " + amount + " of " + cargo + " to " + Stationname;
        Track = false;
    }

    public void Abandon_Objective()
    {
        Destroy(gameObject);
    }
    public void CheckForTrack(int check)
    {
        Debug.Log("Checking for tracking");
        if (check != ID)
        {
            Track = false;
            trackText.text = "Track";
        }
    }

    public void Track_Objective(bool track)
    {
        track = Track;
        if (!track)
        {
            Debug.Log("tracking objective: " + location);
            ObjectiveHandler.objHandler.DoCheck(ID);
            TrackingUI.trackingUI.objectiveMarker = location;
            TrackingUI.trackingUI.objectiveMarkerName = Stationname;
            Track = true;
            trackText.text = "Untrack";
        }
        
        if (track)
        {
            Debug.Log("No longer tracking: " + location);
            TrackingUI.trackingUI.objectiveMarker = Vector3.zero;
            Track = false;
            trackText.text = "Track";
        }
    }
}
