using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class StationManager : MonoBehaviour
{
    public CargoRootScript[] assignmentResources;
    public AcceptedOrder[] CargoOrders;
    public int ID;
    public string type;
    public int CargoNum;

    void FixedUpdate()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        transform.Rotate(0, 0.07f, 0);
    }

    public void Configuration(stationSettings config)
    {
        gameObject.name = config.name;
        ID = config.iD;
        type = config.type;
        CargoNum = 0;
    }

    public void HoldCargoInBay(AcceptedOrder cargo)
    {
        CargoNum++;

        if (CargoOrders != null)
        {
            AcceptedOrder[] temparray = new AcceptedOrder[CargoOrders.Length];
            int i = 0;
            foreach (AcceptedOrder order in CargoOrders)
            {
                temparray[i] = order;
                i++;
            }

            int j = 0;
            CargoOrders = new AcceptedOrder[CargoNum];
            foreach (AcceptedOrder order in temparray)
            {
                CargoOrders[j] = order;
                j++;
            }
            CargoOrders[CargoNum - 1] = cargo;
        }
        else
        {
            CargoOrders = new AcceptedOrder[CargoNum];
            CargoOrders[CargoNum - 1] = cargo;
        }

        
        Debug.Log("CargoMoved to bay: " + cargo.AOcargo);
    }
}
