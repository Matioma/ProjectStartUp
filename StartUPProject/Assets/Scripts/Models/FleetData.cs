using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetData
{
    int maxWarShips=10;
    int maxDefenseShips=10;
    int maxStorageShips;



    public bool HasAvailableSlot(Type shipType, int ShipCount)
    {
        if (shipType == typeof(AttackShip)) {
            if (ShipCount < maxWarShips) {
                return true;
            }              
        }
        if (shipType == typeof(DefenceShip))
        {
            if (ShipCount < maxDefenseShips)
            {
                return true;
            }
        }
        return false;
    }
}
