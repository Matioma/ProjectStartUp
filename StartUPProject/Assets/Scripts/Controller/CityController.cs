using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    [SerializeField]
    IFleetAction fleetActions;

    private void Start()
    {
        fleetActions = FindObjectOfType<FleetModel>();
    }


    public void BuyShip(string ship) {
        if (Enum.TryParse(ship, out ShipTypes shipToBuy)) {
            BuyShip(shipToBuy);
        }
    }


    public void BuyShip(ShipTypes shipTypes) {
        fleetActions.AddShip(shipTypes);
    }




}
