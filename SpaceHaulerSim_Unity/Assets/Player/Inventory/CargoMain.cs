using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoMain : MonoBehaviour
{
    static public CargoMain CargoMainScript;
    public AcceptedOrder[] AllStoredOrders;
    public int cargoCap;
    public int currentloading;

    private void Start()
    {
        CargoMainScript = this;
        AllStoredOrders = new AcceptedOrder[cargoCap];
        currentloading = 0;
    }

    public void LoadCargo(AcceptedOrder cargoloading)
    {
        AllStoredOrders[currentloading] = cargoloading;
        currentloading++;

        Debug.Log(currentloading);
        Debug.Log(cargoloading.AOcargo);
    }
}
