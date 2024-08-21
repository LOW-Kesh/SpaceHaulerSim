using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssignmentHandler : MonoBehaviour
{
    public static AssignmentHandler assignmentHandler;

    public bool reset;
    public GameObject order;
    public GameObject content;
    public int orderCount;

    public AcceptedOrder[] orderList;
    private GameObject[] generatedOrders;

    void Start()
    {
        assignmentHandler = this;
        reset = false;

        orderCount = Random.Range(1, 5);
        for (int i = 0; i < orderCount; i++)
        {
            Instantiate(order, content.transform);
        }

        int j = 0;
        generatedOrders = GameObject.FindGameObjectsWithTag("Order");
        foreach (GameObject genorder in generatedOrders)
        {
            genorder.GetComponent<OrderGenerator>().orderCount = j;
            j++;
        }


        orderList = null;
        orderList = new AcceptedOrder[orderCount];
    }

    void Update()
    {
        if (reset)
        {
            foreach (GameObject ord in generatedOrders)
            {
                Destroy(ord);
            }
            generatedOrders = null;

            orderCount = Random.Range(1, 5);
            for (int i = 0; i < orderCount; i++)
            {
                Instantiate(order, content.transform);
            }

            int j = 0;
            generatedOrders = GameObject.FindGameObjectsWithTag("Order");
            foreach (GameObject genorder in generatedOrders)
            {
                genorder.GetComponent<OrderGenerator>().orderCount = j;
                Debug.Log(j);
                j++;
            }
            orderList = new AcceptedOrder[orderCount];
            reset = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           LeaveAssignments();
        }
    }

    //this will hold the accepted orders while in the Assignment Menu. 
    //the player can rescind orders while here without cost]
    //once the player leaves, the accepted orders are carried over, and any abandoned since will carry a cost
    
    public void Assignment_Accept(AcceptedOrder acceptedOrder, int num)
    {
        Debug.Log(acceptedOrder.AOamount);
        orderList[num] = acceptedOrder;
        Debug.Log(orderList[num].AOcargo);
    }

    public void Assignment_Abandon(int num)
    {
        orderList[num] = null;
    }

    public void Assign_Objectives()
    {
        //  commit to the chosen courier assignements. turn courier assignments into mission objectives
        foreach (AcceptedOrder ord in orderList)
        {
            if (ord != null)
            {
                ObjectiveHandler.objHandler.AssignOrder(ord);
                ShipDocking.currentStation.HoldCargoInBay(ord);
            }
        }

        Debug.Log("Assignemnts Commited");
    }

    public void LeaveAssignments()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(3,UnloadSceneOptions.None);
    }


    public void Reset_Assingments()
    {
       reset = true;
    }
}
