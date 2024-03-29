using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManagement : MonoBehaviour
{



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (GameObject component in StateManager.Statemanager.UIcomponents)
            {
                component.SetActive(true);
            }
            SceneManager.UnloadSceneAsync("Inventory", UnloadSceneOptions.None);
            StateManager.Statemanager.UnPause();
        }
    }
}
