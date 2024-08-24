using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class cargoHold : ScriptableObject
{
    //capacity 
    public float maxCapacity;

    //carrying
    public string[] cargoCarrying;

    //modifiers
    public int modiferMax;
    public int modifierCount;
    public bool radSheilding;
    public bool farradyCage;
    public bool scanSheilding;
}
