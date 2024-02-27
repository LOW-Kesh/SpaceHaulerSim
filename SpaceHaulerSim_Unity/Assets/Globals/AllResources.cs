using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllResources : MonoBehaviour
{
    public static AllResources allResources;

    public string[] allCargo;
    public int[] stationSizeCargoVariety;
    private string[] cargoList;
    void Start()
    {
        allResources = this;
        
        //allCargo //= new string[11] { "Metal Alloys", "Stellar Plasma", "Food", "Ammunition", "Organic Compounds", "Delicate Electronics", "Heat Sinks", "Curie Coolant", "Propellant", "Crew Equipment", "Heavy Machinery" };
    }

    public string[] Station_Resource_Generator(string type)
    {
        switch (type)
        {
            case "Waystation":
                cargoList = new string[stationSizeCargoVariety[0]];
                for (int i = 0; i < stationSizeCargoVariety[0]; i++)
                {
                    cargoList[i] = allCargo[Random.Range(0, allCargo.Length)];
                }
                break;

            case "Minor Port":
                cargoList = new string[stationSizeCargoVariety[1]];
                for (int i = 0; i < stationSizeCargoVariety[1]; i++)
                {
                    cargoList[i] = allCargo[Random.Range(0, allCargo.Length)];
                }
                break;

            case "Port":
                cargoList = new string[stationSizeCargoVariety[2]];
                for (int i = 0; i < stationSizeCargoVariety[2]; i++)
                {
                    cargoList[i] = allCargo[Random.Range(0, allCargo.Length)];
                }
                break;

            case "Major Settlement":
                cargoList = new string[stationSizeCargoVariety[3]];
                for (int i = 0; i < stationSizeCargoVariety[3]; i++)
                {
                    cargoList[i] = allCargo[Random.Range(0, allCargo.Length)];
                }
                break;
            default: Debug.Log("ERROR: No station type declared"); break;
        }
        Debug.Log("staion resource list generated");
        return cargoList;
    }
}

