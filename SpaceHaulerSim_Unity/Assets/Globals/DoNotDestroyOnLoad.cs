using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        if (GameObject.FindAnyObjectByType(typeof(DoNotDestroyOnLoad)) != null)
        {
             
        }
    }
}
