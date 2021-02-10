using System;
using System.Collections.Generic;
using UnityEngine;

public class FleetLayout : MonoBehaviour
{
    List<FleetSlot> fleetSlots = new List<FleetSlot>();



    private void Awake()
    {
        foreach (var slot in GetComponentsInChildren<FleetSlot>()) {
            fleetSlots.Add(slot);
        }
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
            newShip.OnShipBuy();
            return true;
        }
        return false;
    }


    public void RemoveShip(IShipActions shipActions) {
        foreach (var fleetSlot in fleetSlots) {
            fleetSlot.FreeSlot(shipActions);
        }
    }


    //Gets an available slot to place a ship
    FleetSlot getAvailableSlot(ShipTypes shipType) {
        foreach (var fleetSlot in fleetSlots) {
            if (!fleetSlot.IsEmpty) continue;

            if (fleetSlot.ShipType == shipType) {
                return fleetSlot;
            }
        }
        return null;
    }



    //Returns all the ships of a specific Type
    public List<IShipActions> GetShips(Type shipType)
    {
        List<IShipActions> resultList = new List<IShipActions>();
        foreach (var shipSlot in fleetSlots)
        {
            IShipActions shipAction = shipSlot.ShipAction;
            if (shipAction == null) continue;

            if (shipAction.GetType().IsSubclassOf(shipType) || shipAction.GetType() == shipType )
            {
                resultList.Add(shipAction);
            }
        }
        return resultList;
    }
}

