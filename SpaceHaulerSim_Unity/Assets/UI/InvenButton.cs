using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class InvenButton : MonoBehaviour
{
    public void Inventory()
    {
        SceneManager.LoadScene("Inventory");
    }
}
