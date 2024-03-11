using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class StationManager : MonoBehaviour
{
    public string[] assignmentResources;
    public int ID;
    public string type;

    void Awake()
    {
    }

    public void Configuration(stationSettings config)
    {
        gameObject.name = config.name;
        ID = config.iD;
        type = config.type;
    }
}
