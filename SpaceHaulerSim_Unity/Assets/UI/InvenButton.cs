using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvenButton : MonoBehaviour
{

    void Start()
    {
    }
    public void InventoryOpen()
    {
        foreach (var component in StateManager.Statemanager.UIcomponents)
        {
            component.SetActive(false);
        }
        StateManager.Statemanager.Pause();
        SceneManager.LoadSceneAsync("Inventory", LoadSceneMode.Additive);
    }
}
