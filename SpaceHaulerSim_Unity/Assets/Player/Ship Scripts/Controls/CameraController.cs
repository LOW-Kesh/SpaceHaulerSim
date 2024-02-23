using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject port;
    public GameObject starboard;
    public GameObject devcam;

    private GameObject activeCam;
    public float rotationSpeed;
    public float zoomSpeed;
    public float minFOV; public float maxFOV;

    void Start()
    {
        port.SetActive(false); starboard.SetActive(false); devcam.SetActive(true);
        activeCam = devcam;
    }

    void Update()
    {
        //camera swapper
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            starboard.SetActive(false); devcam.SetActive(false); port.SetActive(true);
            activeCam = port;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            port.SetActive(false); devcam.SetActive(false); starboard.SetActive(true);
            activeCam = starboard;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            starboard.SetActive(false); port.SetActive(false); devcam.SetActive(true);
            activeCam = devcam;
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
        if(Input.GetKey(KeyCode.O))
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
