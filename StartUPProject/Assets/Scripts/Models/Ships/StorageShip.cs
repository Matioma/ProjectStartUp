using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageShip : Ship
{
    public override void OnShipBuy()
    {
        Debug.Log("StorageShip received");
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateSelf()
    {
        throw new System.NotImplementedException();
    }

    public override IShipActions CreateShip(FleetModel fleetModel)
    {
        base.CreateShip(fleetModel);
        return this;
    }

    public override void OnDestroy()
    {
        throw new System.NotImplementedException();
    }
}

