using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldShipView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI name;

    [SerializeField]
    TextMeshProUGUI level;


    FleetModel fleetModel;

    private void Start()
    {
        Display();
        fleetModel = FindObjectOfType<FleetModel>();
    }

    void Display() {
        WorldFleetBehaviour data = GetComponentInParent<WorldFleetBehaviour>();
        
        if (data.worldFleetData.isPlayer)
        {
            name.text = "Your Ship";
            level.text ="1";
        }
        else {
            name.text = "Player" + Random.Range(1, 100);
            level.text = "1";
        }
    }
}
