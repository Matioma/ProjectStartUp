using UnityEngine;

public class FleetLayout : MonoBehaviour
{
    FleetSlot[] fleetSlots;



    private void Awake()
    {
        fleetSlots = GetComponentsInChildren<FleetSlot>();
    }



    /// <summary>
    /// Fiil the slot with a ship type
    /// </summary>
    /// <param name="newShip">Ship interface</param>
    /// <param name="prefab">visual prefab</param>
    /// <param name="shipTypes">Ship type</param>
    /// <returns>true is could add the ship, false if not</returns>
    public bool FillSlot(IShipActions newShip, GameObject prefab, ShipTypes shipTypes) {
        FleetSlot fleetSlot = getAvailableSlot(shipTypes);
        if (fleetSlot != null)
        {
            fleetSlot.FillSlot(newShip, prefab);
            return true;
        }
        return false;
    }


    public void RemoveShip(IShipActions shipActions) {
        foreach (var fleetSlot in fleetSlots) {
            fleetSlot.FreeSlot(shipActions);
        }
    }


    //Gets an available slot
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

