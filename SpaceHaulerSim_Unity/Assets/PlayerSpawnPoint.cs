using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnPoint : MonoBehaviour
{
    public static PlayerSpawnPoint playerSpawnPoint;

    public GameObject player;
    public Transform spawnPoint;

    private void Start()
    {
        playerSpawnPoint = this;
    }

    void FixedUpdate()
    {
        
    }

    public void Spawn_Player(Transform spawnTran, bool reset)
    {
        if (reset)
        {
            Debug.Log("player intial instantiation");
            Instantiate(player, gameObject.transform.position, gameObject.transform.rotation, null);
            spawnPoint = gameObject.transform;
        }
        else if (!reset)
        {
            gameObject.transform.position = spawnTran.position;
            Instantiate(player, spawnTran, true);
            spawnPoint = gameObject.transform;
        }
    }
}
