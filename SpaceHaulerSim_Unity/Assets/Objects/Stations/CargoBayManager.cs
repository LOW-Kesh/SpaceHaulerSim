
using UnityEngine;

public class CargoBayManager : MonoBehaviour
{
    private AcceptedOrder[] OrdersInBay;
    public GameObject CargoInBay;
    public GameObject content;

    void Start()
    {
        OrdersInBay = AccessCargo();
        DisplayOrdersInBay();
    }
    public void DisplayOrdersInBay()
    {
        foreach (AcceptedOrder cargoOrder in OrdersInBay)
        {
            if (cargoOrder != null)
            {
                CargoInBay.GetComponent<CargoInBayScript>().cargoInfo = cargoOrder.AOamount.ToString() + " units of " + cargoOrder.AOcargo + ". Destination: " + cargoOrder.AOlocation.name; ;
                Instantiate(CargoInBay, content.transform);
            }
        }
    }

    private AcceptedOrder[] AccessCargo()
    {
        AcceptedOrder[] cargoInStation;
        cargoInStation = ShipDocking.currentStation.CargoOrders;
        return cargoInStation;
    }
}
