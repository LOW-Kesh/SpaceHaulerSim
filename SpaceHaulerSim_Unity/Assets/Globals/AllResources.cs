using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllResources : MonoBehaviour
{
    static public AllResources allResources;

    public string[] allCargo;
    private string[] cargoList;

    public int[] stationSizeCargoVariety;

    void Awake()
    {
        allResources = this;
        allCargo = new string[11] { "Metal Alloys", "Stellar Plasma", "Food", "Ammunition", "Organic Compounds", "Delicate Electronics", "Heat Sinks", "Curie Coolant", "Propellant", "Crew Equipment", "Heavy Machinery" };
    }


    public string[] Resource_List_Station(string type)
    {

        switch (type)
        {
            case "Waystation":

                cargoList = new string[stationSizeCargoVariety[0]];
                for (int i = 0; i < stationSizeCargoVariety[0]; i++)
                {
                    cargoList[i] = allCargo[Random.Range(0,allCargo.Length)];
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
        }
        return cargoList;
    }
}
