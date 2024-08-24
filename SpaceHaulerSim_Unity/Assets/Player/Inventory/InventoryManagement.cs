using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManagement : MonoBehaviour
{
    public cargoHold[] HoldsOnShip;
    public GameObject holdslot;
    public GameObject holdselector;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
        TextMeshProUGUI[] textholder = new TextMeshProUGUI[3];

        foreach (cargoHold hold in HoldsOnShip)
        {
            textholder = holdslot.GetComponentsInChildren<TextMeshProUGUI>();
            textholder[0].text = hold.name;
            textholder[1].text = hold.currentCapacity.ToString() + "/" + hold.maxCapacity.ToString();
            Instantiate(holdslot, holdselector.transform);
        }
    }
}
