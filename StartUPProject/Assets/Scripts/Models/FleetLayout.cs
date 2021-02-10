using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetLayout : MonoBehaviour
{
    FleetSlot[] fleetSlots;

    private void Awake()
    {
        fleetSlots =GetComponentsInChildren<FleetSlot>(); 
    }

    public void FillSlot(IShipActions newShip, GameObject prefab) {
        if(getAvailableSlot() != null)
        {
            Instantiate(prefab, getAvailableSlot().transform);
            
        }
    }

    public bool CanAddShip(FleetSlot fleetSlot) {
        
        return false;
    }



    FleetSlot getAvailableSlot() {

        return fleetSlots[0];
    }



}

