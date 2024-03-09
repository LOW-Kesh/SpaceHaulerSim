using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationSpawnpoint : MonoBehaviour
{
    public GameObject station;
    public bool spawned;
    private GameObject ship;
    public float enableDist;

    //spawn configurations
    public stationSettings stationSpawnSettings;

    private StationManager stationmanager;

    private void Start()
    {

        stationSpawnSettings = AllStationManager.allStations.configSettings;
        Debug.Log(stationSpawnSettings.name);

        Instantiate(station, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
        stationmanager = GetComponentInChildren<StationManager>();

        stationmanager.name = stationSpawnSettings.name;
        stationmanager.ID = stationSpawnSettings.iD;
        stationmanager.Type = stationSpawnSettings.type;
        stationmanager.gameObject.SetActive(false);

        ship = shipcontrols.shipControls.gameObject;
    }

    void FixedUpdate()
    {

        if (Vector3.Distance(ship.transform.position, gameObject.transform.position) <= enableDist && !spawned)
        {
            stationmanager.gameObject.SetActive(true);
            spawned = true;
        }
        else if (Vector3.Distance(ship.transform.position, gameObject.transform.position) > enableDist && spawned)
        {
            stationmanager.gameObject.SetActive(false);
            spawned = false;
        }
    }
}
