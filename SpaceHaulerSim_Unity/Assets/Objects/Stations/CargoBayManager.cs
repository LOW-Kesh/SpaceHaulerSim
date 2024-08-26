
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargoBayManager : MonoBehaviour
{
    static public CargoBayManager cargoBayMan;
    private AcceptedOrder[] OrdersInBay;
    public GameObject CargoInBay;
    public GameObject content;
    public TextMeshProUGUI capIndicator;
    public float bayCap;
    private float currentAlloc;
    private int inbayID;

    void Start()
    {
        cargoBayMan = this;
        OrdersInBay = AccessCargo();
        DisplayOrdersInBay();
        capIndicator.text = bayCap.ToString();
        inbayID = 0;
    }

    public void DisplayOrdersInBay()
    {
        foreach (AcceptedOrder cargoOrder in OrdersInBay)
        {
            if (cargoOrder != null)
            {
                CargoInBay.GetComponent<CargoInBayScript>().cargoInfo = cargoOrder.AOamount.ToString() + " units of " + cargoOrder.AOcargo + ". Destination: " + cargoOrder.AOlocation.name;
                CargoInBay.GetComponent<CargoInBayScript>().cargoinbayID = inbayID;
                currentAlloc += cargoOrder.AOamount;
                Instantiate(CargoInBay, content.transform);
                inbayID++;
            }
        }

        capIndicator.text = (bayCap -= currentAlloc).ToString();
    }

    private AcceptedOrder[] AccessCargo()
    {
        AcceptedOrder[] cargoInStation;
        cargoInStation = ShipDocking.currentStation.CargoOrders;
        return cargoInStation;
    }

    public void LoadCargoToShip(int ID)
    {
        CargoMain.CargoMainScript.LoadCargo(OrdersInBay[ID]);
        OrdersInBay[ID] = null;
    }

    public void leaveCargoBay()
    {
        StateManager.Statemanager.LeaveMenu(5, 2);
    }
}
