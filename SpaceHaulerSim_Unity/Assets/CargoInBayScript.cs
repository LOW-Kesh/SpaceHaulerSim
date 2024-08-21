using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CargoInBayScript : MonoBehaviour
{
    public string cargoInfo;
    public TextMeshProUGUI cargoinbayText;

    private void Start()
    {
        Debug.Log("cib");
        cargoinbayText.text = cargoInfo;
    }
}
