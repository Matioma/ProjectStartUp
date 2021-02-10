using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFleetAction
{
    void AddShip(ShipTypes shipType);

    void SelectShip(Ship ship);

    Ship GetSelectedShip();
}
