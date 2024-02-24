using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class StationManager : MonoBehaviour
{
    private bool alreadyAwake;
    public string[] assignmentResources;
    public string stationType;

    private void Awake()
    {
        if (!alreadyAwake)
        {
            Set_Resources();
            alreadyAwake = true;
        }
    }

    public void Set_Resources()
    {
        assignmentResources = AllResources.allResources.Station_Resource_Generator(stationType);
        Debug.Log("Set Station Resources");
    }
}
