using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageShip : Ship
{
    public int woodStorage=120;
    public int goldStorage=150;
    public int orangeStorage=300;


    public override void OnShipBuy()
    {
        this.AddStorage(goldStorage, woodStorage, orangeStorage);
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
        this.ReduceStorage(goldStorage, woodStorage, orangeStorage);
    }
}

