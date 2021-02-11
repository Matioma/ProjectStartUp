using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingShip : Ship
{

    public override void OnShipBuy()
    {
        base.OnShipBuy();
    }

    public override void Update()
    {
        Debug.Log("This is Trainining Ship");
    }

    public override void Upgrade()
    {
        Debug.Log("Training Ship Upgraded");
    }
    public override void ApplyFleetUpgrades()
    {
    }

    public override IShipActions CreateShip(FleetModel fleetModel, ShipPrice price)
    {
        base.CreateShip(fleetModel,price);
        return this;
    }

    public override void OnDestroy()
    {
        throw new System.NotImplementedException();
    }
}
