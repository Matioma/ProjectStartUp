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



    public void TestBuy(string ship) {
        if (Enum.TryParse(ship, out ShipTypes shipToBuy)) {
            TestBuy(shipToBuy);
        }

      
    }


    public void TestBuy(ShipTypes shipTypes) {

        fleetActions.AddShip(shipTypes);
    }




}
