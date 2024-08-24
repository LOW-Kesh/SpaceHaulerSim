using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManagement : MonoBehaviour
{
    public cargoHold[] HoldsOnShip;

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
}
