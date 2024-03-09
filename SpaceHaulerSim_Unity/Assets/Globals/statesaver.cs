using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class statesaver : MonoBehaviour
{
    public static statesaver Statesaver;
    public bool reset;
    private bool spawned;
    public Transform playerTran;

    void Start()
    {
        Statesaver = this;
        Debug.Log("Game Start");
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        Debug.Log("Main scene loaded");

        //intialise things
        reset = true;
        spawned = false;

    }

    void Update()
    {
        if (reset)
        {
            //spawn player
            if (PlayerSpawnPoint.playerSpawnPoint != null && !spawned)
            {
                PlayerSpawnPoint.playerSpawnPoint.Spawn_Player(null, reset);
                spawned = true;
                reset = false;
            }

            //spawn stations
            if (AllStationManager.allStations != null)
            {
                Debug.Log("stations spawned");
                AllStationManager.allStations.SpawnStations();
            }
        }

    }

    public void SavePlayerState()
    {

    }
}
