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
            FleetSlot fleetSlot = getAvailableSlot();
            Instantiate(prefab, fleetSlot.transform);
            fleetSlot.IsEmpty = false;
        }
    }

    public bool CanAddShip(ShipTypes shipTypes) {
        foreach (var fleetSlot in fleetSlots) {
            if (fleetSlot.IsEmpty && fleetSlot.ShipType == shipTypes) {
                return true;
            }
        }
        return false;
    }



    FleetSlot getAvailableSlot() {

        return fleetSlots[0];
    }



}

