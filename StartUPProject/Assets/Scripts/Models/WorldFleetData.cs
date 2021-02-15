using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WorldFleetData
{
    //FleetModel fleetData;    

    [SerializeField]
    int Level= 1;
    [SerializeField]
    public Vector2 position = new Vector2(0,0);
    [SerializeField]
    int defencePower = 100;
    public void Init(FleetModel fleetData) {
        //Level = fleetData.Level;
        //position = fleetData.position;
        //defencePower = fleetData.defencePower;
    }
    
}
