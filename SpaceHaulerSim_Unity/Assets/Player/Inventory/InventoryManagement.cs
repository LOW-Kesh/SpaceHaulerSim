using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManagement : MonoBehaviour
{
    //private AcceptedOrder[] ordersInHold;
    public GameObject orderSlot;
    public GameObject orderList;

    public GameObject eventSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            eventSystem.SetActive(false);
            foreach (GameObject component in StateManager.Statemanager.UIcomponents)
            {
                component.SetActive(true);
            }
            StateManager.Statemanager.UnPause();
            SceneManager.UnloadSceneAsync("Inventory", UnloadSceneOptions.None);
        }
    }

    private void Start()
    {
        TextMeshProUGUI[] textholder = new TextMeshProUGUI[5];

        if (CargoMain.CargoMainScript.currentloading != 0)
        {
            foreach (AcceptedOrder ord in CargoMain.CargoMainScript.AllStoredOrders)
            {
                textholder = orderSlot.GetComponentsInChildren<TextMeshProUGUI>();
                textholder[0].text = ord.AOcargo;
                textholder[1].text = ord.AOamount.ToString();
                textholder[2].text = ord.AOlocation.name;
                Instantiate(orderSlot, orderList.transform);
            }
        }
    }
}
