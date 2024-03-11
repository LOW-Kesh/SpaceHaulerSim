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

    private StationSpawnpoint[] configSettings;
    public stationSettings[] AllStationData;

    void Start()
    {
        allStations = this;
    }

    public void SpawnStations()
    {
        AllStationData = new stationSettings[allStationSpawnPositions.Length];

        foreach (Vector3 spawn in allStationSpawnPositions)
        {
            Instantiate(stationSpawner, spawn, Quaternion.identity, gameObject.transform);
        }

        configSettings = gameObject.GetComponentsInChildren<StationSpawnpoint>();

        int i = 0; 
        foreach (StationSpawnpoint set in configSettings)
        {
            Debug.Log(set.gameObject.transform.position);
            stationSettings config = new stationSettings();
            config.iD = i;
            config.name = allStationName[i];
            config.type = allStationType[i];
            config.location = allStationSpawnPositions[i];

            set.stationSpawnSettings = config;
            AllStationData[i] = config;
            i++;
        }
    }
}

public class stationSettings
{
    public int iD;
    public string name;
    public string type;
    public Vector3 location;
}
