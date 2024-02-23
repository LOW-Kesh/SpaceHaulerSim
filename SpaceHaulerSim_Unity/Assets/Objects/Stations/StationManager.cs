using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class StationManager : MonoBehaviour
{
    public string[] assignmentCargo;
    public string stationType;

    public void Awake()
    {
        Generate_Resources();
    }

    public void Generate_Resources()
    {
        //assignmentCargo = AllResources.allResources.Resource_List_Station(stationType);
    }
}
