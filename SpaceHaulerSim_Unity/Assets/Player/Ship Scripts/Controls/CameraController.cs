using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController cameraController;

    public GameObject port;
    public GameObject starboard;
    public GameObject stern;

    private GameObject activeCam;
    public float rotationSpeed;
    public float zoomSpeed;
    public float minFOV; public float maxFOV;

    void Start()
    {
        port.SetActive(true); starboard.SetActive(false); stern.SetActive(false);
        activeCam = port;
    }

    void Update()
    {
        if (!StateManager.Statemanager.pauseScene)
        {
            //camera swapper
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                starboard.SetActive(false); stern.SetActive(false); port.SetActive(true);
                activeCam = port;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                port.SetActive(false); stern.SetActive(false); starboard.SetActive(true);
                activeCam = starboard;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                starboard.SetActive(false); port.SetActive(false); stern.SetActive(true);
                activeCam = stern;
            }

            //pitch and yaw
            if (Input.GetKey(KeyCode.I))
            {
                activeCam.transform.Rotate(Vector3.right * -rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.K))
            {
                activeCam.transform.Rotate(Vector3.right * rotationSpeed);
            }

            //Port and Starboard
            if (Input.GetKey(KeyCode.J))
            {
                activeCam.transform.Rotate(Vector3.up * -rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                activeCam.transform.Rotate(Vector3.up * rotationSpeed);
            }

            //zoom
            if (Input.GetKey(KeyCode.O))
            {
                if (activeCam.GetComponent<Camera>().fieldOfView < maxFOV)
                {
                    activeCam.GetComponent<Camera>().fieldOfView += zoomSpeed;
                }
            }
            if (Input.GetKey(KeyCode.U))
            {
                if (activeCam.GetComponent<Camera>().fieldOfView > minFOV)
                {
                    activeCam.GetComponent<Camera>().fieldOfView -= zoomSpeed;
                }
            }
        }
    }
}
