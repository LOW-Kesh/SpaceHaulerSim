using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationSpawner : MonoBehaviour
{
    public GameObject station;

    void Start()
    {
        
    }

    void Update()
    {
        if (AllResources.allResources != null) 
        {
            Instantiate(station, gameObject.transform.position, Quaternion.identity);
        }
    }
}
