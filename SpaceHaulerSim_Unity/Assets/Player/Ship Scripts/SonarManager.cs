using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarManager : MonoBehaviour
{
    public GameObject sonarCam;
    private bool sonarOn;

    private void Start()
    {
        sonarCam.SetActive(false);
    }

    void Update()
    {
        if (!StateManager.Statemanager.pauseScene)
        {
            //camera swapper
            if (Input.GetKeyDown(KeyCode.N) && !sonarOn)
            {
                sonarOn = true;
                sonarCam.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.N) && sonarOn)
            {
                sonarOn = false;
                sonarCam.SetActive(false);
            }
        }
    }
}        
