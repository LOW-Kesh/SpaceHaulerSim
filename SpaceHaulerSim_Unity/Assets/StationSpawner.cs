using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationSpawner : MonoBehaviour
{
    public GameObject station;
    public bool spawn;

    void Start()
    {
        spawn = false;
    }

    void FixedUpdate()
    {
        if (AllResources.allResources != null & !spawn) 
        {
            Instantiate(station, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            spawn = true;
        }
    }
}
