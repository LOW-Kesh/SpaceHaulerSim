using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class dockingScript : MonoBehaviour
{
    public bool shipDocked;
    public bool withinRange;
    private GameObject ship;
    public GameObject[] Uicomponents;
    static public bool leave;

    void Start()
    {
       shipDocked = false;
       withinRange = false;
       leave = false;
       Uicomponents = GameObject.FindGameObjectsWithTag("UI");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered docking range");
            ship = other.gameObject;
            withinRange = true;
        }
        
    }

    private void Update()
    {
        if (withinRange)
        {
            if (Input.GetKeyDown(KeyCode.Return) && !shipDocked)
            {
                Debug.Log("Ship Docked");
                shipDocked = true;
                leave = false;

                //pause ship controls and scene
                ship.GetComponent<ShipDocking>().HoldShip(true);
                ShipDocking.currentStation = gameObject.GetComponentInParent<StationManager>();
                StateManager.Statemanager.Pause();
                StateManager.Statemanager.inMenu = true;

                //turn off UI in main scene 
                foreach (var item in Uicomponents)
                {
                    item.SetActive(false);
                }

                //load the new scene on top of others
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            }
            if (leave && shipDocked)
            {
                Debug.Log("Ship Departing");
                shipDocked = false;
                ship.GetComponent<ShipDocking>().docked = false;

                //remove old scene
                SceneManager.UnloadSceneAsync(2, UnloadSceneOptions.None);

                //turn on UI in main scene 
                foreach (var item in Uicomponents)
                {
                    item.SetActive(true);
                }

                //unpause scene
                StateManager.Statemanager.UnPause();
                StateManager.Statemanager.inMenu = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Leaving docking range");
            withinRange = false;
        }
    }
}
