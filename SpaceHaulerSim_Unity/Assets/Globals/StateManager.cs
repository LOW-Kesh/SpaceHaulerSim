using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public static StateManager Statemanager;
    public GameObject[] UIcomponents;
    public bool reset;
    private bool spawned;
    public Transform playerTran;
    public bool pauseScene;
    public GameObject pauseMenu;
    public bool inMenu;


    void Start()
    {
        Statemanager = this;
        Debug.Log("Game Start");
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        Debug.Log("Main scene loaded");

        //intialise things
        reset = true;
        spawned = false;
        pauseScene = false;
        pauseMenu.SetActive(false);
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

            //gather UI components in scene
            UIcomponents = GameObject.FindGameObjectsWithTag("UI");
        }
        if (!inMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pauseScene)
                {
                    Pause();
                    foreach (GameObject component in UIcomponents)
                    {
                        component.SetActive(false);
                    }
                    pauseMenu.SetActive(true);
                }
                else if (pauseScene)
                {
                    if (pauseMenu.activeSelf == true)
                    {
                        pauseMenu.SetActive(false);
                        foreach (GameObject component in UIcomponents)
                        {
                            component.SetActive(true);
                        }
                    }
                    UnPause();
                }
            }
        }

    }

    public void Pause()
    {
        pauseScene = true;
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        pauseScene = false;
        Time.timeScale = 1;
    }

    public void LeaveMenu(int unloadScene, int loadScene)
    {
        SceneManager.UnloadSceneAsync(unloadScene, UnloadSceneOptions.None);
        SceneManager.LoadSceneAsync(loadScene, LoadSceneMode.Additive);
    }
}
