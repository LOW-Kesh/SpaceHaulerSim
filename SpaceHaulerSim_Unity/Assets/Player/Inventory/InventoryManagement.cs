using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        TextMeshProUGUI[] textholder = new TextMeshProUGUI[7];

        if (CargoMain.CargoMainScript.currentloading != 0)
        {
            foreach (AcceptedOrder ord in CargoMain.CargoMainScript.AllStoredOrders)
            {
                if (ord != null)
                {
                    //stuf related to order
                    textholder = orderSlot.GetComponentsInChildren<TextMeshProUGUI>();
                    textholder[0].text = ord.AOcargo;
                    textholder[1].text = ord.AOamount.ToString();
                    textholder[2].text = ord.AOlocation.name;


                    CargoRootScript cargo = AllResources.allResources.allCargo[ord.AOcargoID];
                    textholder[3].text = (cargo.cargoValue * ord.AOamount).ToString();
                    textholder[4].text = (cargo.cargoWeight * ord.AOamount).ToString();
                    textholder[5].text = cargo.cargoVulnerabilites;
                    textholder[6].text = cargo.cargoHazards;
                    orderSlot.GetComponentInChildren<RawImage>().texture = cargo.cargoSprite;

                    Instantiate(orderSlot, orderList.transform);
                }
            }
        }
    }
}
