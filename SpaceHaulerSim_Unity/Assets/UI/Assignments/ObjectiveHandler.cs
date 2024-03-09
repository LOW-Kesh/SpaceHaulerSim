using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{
    static public ObjectiveHandler objHandler;
    public GameObject assigned;
    public GameObject content;

    private void Awake()
    {
        objHandler = this;
    }

    public void AssignOrder(AcceptedOrder order)
    {
        assigned.GetComponent<AssignedOrders>().title = order.AOtitle;
        assigned.GetComponent<AssignedOrders>().cargo = order.AOcargo;
        assigned.GetComponent<AssignedOrders>().amount = order.AOamount;
        assigned.GetComponent<AssignedOrders>().location = order.AOlocation;
        Instantiate(assigned, content.transform);
    }
}
