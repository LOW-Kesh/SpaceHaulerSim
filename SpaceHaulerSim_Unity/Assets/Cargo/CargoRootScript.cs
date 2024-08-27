using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
// root for all cargo
public class CargoRootScript : ScriptableObject
{
    public string cargoName;
    public int cargoID;
    public string cargoDesc;
    public Sprite cargoSprite;
    public bool isFunctional;
    public float cargoValue;
    public float cargoWeight;
    public string cargoHazards;
    public int cargoHazardID;
    public string cargoVulnerabilites;
    public int cargoVulID;
}
