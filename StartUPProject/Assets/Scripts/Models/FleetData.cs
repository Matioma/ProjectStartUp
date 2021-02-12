using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetData
{
    int attackShips=0;
    int maxDefenseShips=0;
    int maxStorageShips;


    public void IncreaseAttackShipsCapacity(int amount) {
        attackShips += amount;
    }
    public void IncreaseDefenceShipsCapacity(int amount)
    {
        maxDefenseShips += amount;
    }

    public bool HasAvailableSlot(Type shipType, int ShipCount)
    {
        if (shipType == typeof(AttackShip)) {
            if (ShipCount < attackShips) {
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
