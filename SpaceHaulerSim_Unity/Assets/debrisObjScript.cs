using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class debrisObjScript : MonoBehaviour
{
    public Rigidbody rb;
    private BoxCollider net;
    private GameObject player;
    public float minSpeed;
    public float maxSpeed;

    void Start()
    {
        rb.AddForce(Random.insideUnitSphere.normalized * Random.Range(minSpeed, maxSpeed));
        rb.AddTorque(Random.insideUnitSphere.normalized);
        gameObject.transform.localScale = new Vector3(1,1,1) * Random.value;
        
    }

    void Update ()
    {
        StartCoroutine(CleanUp());
    }

    IEnumerator CleanUp()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        yield return new WaitForSeconds(4);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 30)
        {
            Debug.Log("debris cleaned up");
            Destroy(gameObject);
        }

    }
}
