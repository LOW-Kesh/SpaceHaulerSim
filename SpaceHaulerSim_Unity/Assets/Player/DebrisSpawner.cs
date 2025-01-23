using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    public Mesh[] debrisMeshList;
    public GameObject debrisObject;
    private GameObject[] DebrisField;
    private Mesh debrisMesh;
    public int maxDebrisCount;
    private Vector3 debrisSpawnpoint;
    public BoxCollider debrisnet;
    public float debrisCount;


    private void Start()
    {
        DebrisField = GameObject.FindGameObjectsWithTag("Debris");
        debrisCount = DebrisField.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (debrisCount < maxDebrisCount) 
        {
            debrisMesh = debrisMeshList[Random.Range(0, debrisMeshList.Length)];
            debrisSpawnpoint = RandomPointInNet(debrisnet.bounds)  - gameObject.transform.position;
            debrisObject.GetComponent<MeshFilter>().mesh = debrisMesh;
            Instantiate(debrisObject, debrisSpawnpoint + gameObject.transform.position, Quaternion.identity);

            DebrisField = GameObject.FindGameObjectsWithTag("Debris");
            debrisCount = DebrisField.Length;
        }
    }

    public Vector3 RandomPointInNet(Bounds net)
    {
        return new Vector3(
            Random.Range(net.min.x, net.max.x),
            Random.Range(net.min.y, net.max.y),
            Random.Range(net.min.z, net.max.z)
            );
    }

//Random.insideUnitSphere* Random.Range(minSpawnDist, maxSpawnDist);


    private void OnTriggerExit(Collider debrisLeaving)
    {
        if (debrisLeaving.gameObject.tag == "Debris")
        {
            Destroy(debrisLeaving.gameObject);
            DebrisField = GameObject.FindGameObjectsWithTag("Debris");
            debrisCount = DebrisField.Length;
        }
    }
}
