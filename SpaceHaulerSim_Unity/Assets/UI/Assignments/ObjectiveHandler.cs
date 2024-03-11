using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{
    static public ObjectiveHandler objHandler;
    public GameObject assigned;
    public GameObject content;
    private int assignedOrdersID;

    private void Awake()
    {
        objHandler = this;
        assignedOrdersID = 0;
    }

    public void AssignOrder(AcceptedOrder order)
    {
        assignedOrdersID++;
        assigned.GetComponent<AssignedOrders>().ID = assignedOrdersID;
        assigned.GetComponent<AssignedOrders>().title = order.AOtitle;
        assigned.GetComponent<AssignedOrders>().cargo = order.AOcargo;
        assigned.GetComponent<AssignedOrders>().amount = order.AOamount;
        assigned.GetComponent<AssignedOrders>().location = order.AOlocation.location;
        assigned.GetComponent<AssignedOrders>().Stationname = order.AOlocation.name;
        Instantiate(assigned, content.transform);
    }

    public void DoCheck(int check)
    {
        AssignedOrders[] objectives = GetComponentsInChildren<AssignedOrders>();
        foreach (AssignedOrders order in objectives)
        {
            order.CheckForTrack(check);
        }
    }
}
