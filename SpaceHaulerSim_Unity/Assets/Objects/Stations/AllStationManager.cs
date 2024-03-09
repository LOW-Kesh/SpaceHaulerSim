using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllStationManager : MonoBehaviour
{
    public static AllStationManager allStations;
    public GameObject stationSpawner;

    public Vector3[] allStationSpawnPositions;
    public string[] allStationType;
    public string[] allStationName;
    public stationSettings configSettings;

    void Start()
    {
        allStations = this;

    }

    public void SpawnStations()
    {
        int i = 0;
        foreach (Vector3 spawn in allStationSpawnPositions)
        {
            configSettings = new stationSettings();
            configSettings.iD = i;
            configSettings.type = allStationType[i];
            configSettings.name = allStationName[i];

            Instantiate(stationSpawner, spawn, Quaternion.identity, gameObject.transform);
            Debug.Log(configSettings.iD + ", " + configSettings.name);
            i++;
        }
    }
}

public class stationSettings
{
    public int iD;
    public string name;
    public string type;
}
