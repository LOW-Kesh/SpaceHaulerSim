using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveStation : MonoBehaviour
{
    public void Leave_Station()
    {
        SceneManager.LoadScene("MainScene");
    }
}
