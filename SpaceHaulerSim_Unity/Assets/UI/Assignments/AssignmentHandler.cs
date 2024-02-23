using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssignmentHandler : MonoBehaviour
{
    public bool reset;
    public GameObject order;
    public GameObject content;
    public int orderCount;
    private GameObject[] orders;

    void Start()
    {
        reset = false;

        orderCount = Random.Range(1, 5);
        for (int i = 0; i < orderCount; i++)
        {
            Instantiate(order, content.transform);
        }
    }

    void Update()
    {
        if (reset)
        {
            orders = GameObject.FindGameObjectsWithTag("Order");
            foreach (GameObject ord in orders)
            {
                Destroy(ord);
            }

            orderCount = Random.Range(1, 5);
            for (int i = 0; i < orderCount; i++)
            {
                Instantiate(order, content.transform);
            }

            reset = false;
        }
    }

    public void Reset_Assingments()
    {
       reset = true;
    }
}
