using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class StationManager : MonoBehaviour
{
    private bool alreadyAwake;
    public string[] assignmentResources;

    public int ID;
    public string Name;
    public string Type;

    private void Awake()
    {
        if (!alreadyAwake)
        {
            Set_Resources();
            gameObject.name = Name;


            alreadyAwake = true;
        }
    }

    public void Set_Resources()
    {
        assignmentResources = AllResources.allResources.Station_Resource_Generator(Type);
        Debug.Log("Set Station Resources");
    }
}
