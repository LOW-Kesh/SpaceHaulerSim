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

    private TextMeshProUGUI orderText;
    public bool Abandon;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = title + ": " + "Deliver " + amount + " of " + cargo + " to " + location;
    }

    public void Abandon_Objective()
    {
        Destroy(gameObject);
    }
}
