using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityView : MonoBehaviour
{
    FleetModel fleetModel;


    private void Awake()
    {
        fleetModel =FindObjectOfType<FleetModel>();
        fleetModel.onFleetDataChanged += UpdateUI;
    }


    void UpdateUI() {
        Debug.Log("UpdateUI");
        
    }


    private void OnDestroy()
    {
        fleetModel.onFleetDataChanged -= UpdateUI;
    }


}
