using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

    void Start()
    {
       shipDocked = false;
       withinRange = false;
       ship = GameObject.FindGameObjectWithTag("Player");
       Uicomponents = GameObject.FindGameObjectsWithTag("UI");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered docking range");
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
                ship.GetComponent<ShipDocking>().docked = true;

                //turn off UI in main scene 
                foreach (var item in Uicomponents)
                {
                    item.SetActive(false);
                }

                //load the new scene on top of others
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && shipDocked)
            {
                Debug.Log("Ship Departing");
                shipDocked = false;
                ship.GetComponent<ShipDocking>().docked = false;

                //assign objectives
                AssignmentHandler.assignmentHandler.Assign_Objectives();

                //remove old scene
                SceneManager.UnloadSceneAsync(2, UnloadSceneOptions.None);

                //turn on UI in main scene 
                foreach (var item in Uicomponents)
                {
                    item.SetActive(true);
                }
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
