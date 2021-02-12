using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetData
{
    int maxAttackShips=0;
    int maxDefenseShips=0;
    int maxStorageShips=1;

    public int MaxAttackShips => maxAttackShips;
    public int MaxDefenceShips => maxDefenseShips;

    public void IncreaseAttackShipsCapacity(int amount) {
        maxAttackShips += amount;
    }
    public void IncreaseDefenceShipsCapacity(int amount)
    {
        maxDefenseShips += amount;
    }

    public bool HasAvailableSlot(Type shipType, int ShipCount)
    {
        if (shipType == typeof(AttackShip)) {
            if (ShipCount < maxAttackShips) {
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
        if (shipType == typeof(StorageShip))
        {
            if (ShipCount < maxStorageShips)
            {
                return true;
            }
        }
        return false;
    }
}
