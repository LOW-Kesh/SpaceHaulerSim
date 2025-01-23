using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarManager : MonoBehaviour
{
    public GameObject sonarCam;
    private bool sonarOn;
    private Vector3 ShipPos;

    [SerializeField]
    private float rotSpeed;

    private void Start()
    {
        sonarCam.SetActive(false);
    }

    void Update()
    {
        if (!StateManager.Statemanager.pauseScene)
        {
            //camera swapper
            if (Input.GetKeyDown(KeyCode.Tab) && !sonarOn)
            {
                sonarOn = true;
                sonarCam.SetActive(true);
                //reset position
                sonarCam.transform.position = gameObject.transform.position + new Vector3 (-5.45f, 7.33f, 8.96f);
                sonarCam.transform.LookAt(gameObject.transform.position);

                shipcontrols.shipControls.EngineEnabled(false);
            }
            else if (Input.GetKeyDown(KeyCode.Tab) && sonarOn)
            {
                sonarOn = false;
                sonarCam.SetActive(false);
                shipcontrols.shipControls.EngineEnabled(true);
            }
        }

        ShipPos = gameObject.transform.position;

        if (sonarOn)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log(Vector3.Distance(ShipPos, sonarCam.transform.position));
            }
            
            //Rotate around y
            if (Input.GetKey(KeyCode.W))
            {
                sonarCam.transform.RotateAround(ShipPos, sonarCam.transform.right, rotSpeed);
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                sonarCam.transform.RotateAround(ShipPos, -sonarCam.transform.right, rotSpeed);
            }

            //Rotate around z
            if (Input.GetKey(KeyCode.D))
            {
                sonarCam.transform.RotateAround(gameObject.transform.position, sonarCam.transform.up, rotSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                sonarCam.transform.RotateAround(ShipPos, -sonarCam.transform.up, rotSpeed);
            }
            //Zoom
            if (Vector3.Distance(ShipPos, sonarCam.transform.position) >= 7f)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    sonarCam.transform.LookAt(gameObject.transform.position);
                    sonarCam.transform.Translate(sonarCam.transform.forward * 0.1f);
                }
            }
            
            if (Vector3.Distance(ShipPos, sonarCam.transform.position) <= 20f)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    sonarCam.transform.LookAt(gameObject.transform.position);
                    sonarCam.transform.Translate(-sonarCam.transform.forward * 0.1f);
                }
            }
        }
    }
}        
