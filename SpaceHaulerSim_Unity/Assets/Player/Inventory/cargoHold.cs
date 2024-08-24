using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class cargoHold : ScriptableObject
{
    //identifier
    public string Holdname;
    public bool defaultHold;

    //capacity 
    public float maxCapacity;
    public float currentCapacity;

    //carrying
    public string[] cargoCarrying;

    //modifiers
    public int modiferMax;
    public int modifierCount;
    public bool radSheilding;
    public bool farradyCage;
    public bool scanSheilding;
}
