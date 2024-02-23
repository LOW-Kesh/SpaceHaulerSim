using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dockingScript : MonoBehaviour
{
    public bool shipDocked;
    public bool withinRange;
    private GameObject ship;

    void Start()
    {
       shipDocked = false;
       withinRange = false;
       ship = GameObject.FindGameObjectWithTag("Player");
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
        //bool dontDestroy = false;
        if (withinRange)
        {
            if (Input.GetKeyDown(KeyCode.Return) && !shipDocked)
            {
                Debug.Log("Ship Docked");
                shipDocked = true;
                ship.GetComponent<ShipDocking>().docked = true;
                SceneManager.LoadScene("Assignment Screen");
            }
            if (Input.GetKeyDown(KeyCode.Escape) && shipDocked)
            {
                Debug.Log("Ship Departing");
                shipDocked = false;
                ship.GetComponent<ShipDocking>().docked = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            
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
