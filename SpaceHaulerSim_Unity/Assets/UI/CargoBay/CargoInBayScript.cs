using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CargoInBayScript : MonoBehaviour
{
    public string cargoInfo;
    public TextMeshProUGUI cargoinbayText;
    public int cargoinbayID;

    private void Start()
    {
        cargoinbayText.text = cargoInfo;
    }

    public void LoadCargo()
    {
        CargoBayManager.cargoBayMan.LoadCargoToShip(cargoinbayID);
        Destroy(gameObject);
    }
}
