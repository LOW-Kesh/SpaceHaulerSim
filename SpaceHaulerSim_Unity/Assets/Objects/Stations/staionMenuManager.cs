using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class staionMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LeaveButton();
        }
    }

    public void AssignmentMenuButton()
    {
        StateManager.Statemanager.LeaveMenu(2, 3);
        Debug.Log("Assignment Menu");
    }

    public void CargobayButton()
    {
        StateManager.Statemanager.LeaveMenu(2, 5);
        Debug.Log("CargoBay Menu");
    }

    public void LeaveButton()
    {
        dockingScript.leave = true;
    }
}
