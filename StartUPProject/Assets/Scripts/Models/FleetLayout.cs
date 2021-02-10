using UnityEngine;

public class FleetLayout : MonoBehaviour
{
    FleetSlot[] fleetSlots;



    private void Awake()
    {
        fleetSlots =GetComponentsInChildren<FleetSlot>(); 
    }


    public void FillSlot(IShipActions newShip, GameObject prefab, ShipTypes shipTypes) {
        FleetSlot fleetSlot=getAvailableSlot(shipTypes);
        Debug.Log("TEst");
        if (fleetSlot != null)
        {
            Instantiate(prefab, fleetSlot.transform);
            fleetSlot.IsEmpty = false;
        }
        else {
            Debug.Log("Can not add ship " + shipTypes);
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


    FleetSlot getAvailableSlot(ShipTypes shipType) {
        foreach (var fleetSlot in fleetSlots) {
            if (!fleetSlot.IsEmpty) continue;

            if (fleetSlot.ShipType == shipType) {
                return fleetSlot;
            }
        }
        return null;
    }
}

