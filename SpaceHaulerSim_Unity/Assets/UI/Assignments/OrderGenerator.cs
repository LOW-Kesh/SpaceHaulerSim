using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderGenerator : MonoBehaviour
{
    private TextMeshProUGUI orderText;
    public bool orderAccept;
    public GameObject orderButton;

    public StationManager station;

    public int orderCount;

    private string orderTitle;
    private int orderID;
    private float orderAmount;
    private string orderCargo;
    private stationSettings orderLocation;
    //private string orderFluff;

    void Start()
    {
        station = ShipDocking.currentStation;

        Order_Details();

        orderText = GetComponentInChildren<TextMeshProUGUI>();
        orderText.text = "Assignment details. Deliver " + orderAmount.ToString() + " of " + orderCargo + " to " + orderLocation.name + ". Will You Accept?";
        orderAccept = false;
    }

    public void Order_Button()
    {
        if (!orderAccept)
        {
            //accepts the order
            orderAccept = true;
            Debug.Log("Order Accepted");
            GetComponentInChildren<Image>().color = new Color(0.204f, 0.3162003f, 0.2313726f, 1);
            orderButton.GetComponentInChildren<TextMeshProUGUI>().text = "Abandon";

            //create the order as an object
            AcceptedOrder order = new AcceptedOrder();
            order.AOtitle = orderTitle;
            order.AOcargoID = orderID;
            order.AOcargo = orderCargo;
            order.AOamount = orderAmount;
            order.AOlocation = orderLocation;

            //send the object and indentifier over
            AssignmentHandler.assignmentHandler.Assignment_Accept(order, orderCount);
        }

        else if (orderAccept) 
        { 
            //abandons the order
            orderAccept = false;
            Debug.Log("Order Rescinded");
            GetComponentInChildren<Image>().color = new Color(0.3882353f, 0.3162003f, 0.2313726f, 1);
            orderButton.GetComponentInChildren<TextMeshProUGUI>().text = "Accept";

            //deletes object sent over
            AssignmentHandler.assignmentHandler.Assignment_Abandon(orderCount);
        }
    }

    private void Order_Details()
    {
        CargoRootScript cargofororder;
        orderTitle = "Title";
        orderAmount = Random.Range(10, 35);
        cargofororder = station.assignmentResources[Random.Range(0, station.assignmentResources.Length)];
        orderCargo = cargofororder.cargoName;
        orderID = cargofororder.cargoID;

        //choosing a random station to deliver to
        int i = Random.Range(0, AllStationManager.allStations.AllStationData.Length);
        orderLocation = AllStationManager.allStations.AllStationData[i];
        //orderFluff = "Order fluff";
    }
}
public class AcceptedOrder
{
    public int AOcargoID;
    public string AOtitle;
    public string AOcargo;
    public float AOamount;
    public stationSettings AOlocation;
}