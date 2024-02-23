using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderGenerator : MonoBehaviour
{
    private TextMeshProUGUI orderText;
    public bool orderAccept;
    public GameObject orderButton;

    private StationManager station;

    private float orderAmount;
    private string orderCargo;

    void Start()
    {
        station = gameObject.GetComponent<StationManager>();

        Order_Details();

        orderText = GetComponentInChildren<TextMeshProUGUI>();
        orderText.text = "Assignment details [PLACE HOLDER]. Deliver " + orderAmount.ToString() + " of " + orderCargo + ". Will You Accept?";
        orderAccept = false;
    }
    
    void Update()
    {  
    }

    public void Order_Button()
    {
        if (!orderAccept)
        {
            orderAccept = true;
            Debug.Log("Order Accepted");
            GetComponentInChildren<Image>().color = new Color(0.204f, 0.3162003f, 0.2313726f, 1);
            orderButton.GetComponentInChildren<TextMeshProUGUI>().text = "Abandon";
        }

        else if (orderAccept) 
        { 
            orderAccept = false;
            Debug.Log("Order Rescinded");
            GetComponentInChildren<Image>().color = new Color(0.3882353f, 0.3162003f, 0.2313726f, 1);
            orderButton.GetComponentInChildren<TextMeshProUGUI>().text = "Accept";
        }
    }

    private void Order_Details()
    {
        orderAmount = Random.Range(10, 35);
        orderCargo = station.assignmentCargo[Random.Range(0, station.assignmentCargo.Length)];
    }
}
