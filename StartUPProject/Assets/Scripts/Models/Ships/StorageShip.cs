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
        Debug.Log("This is the Storage Ship");
    }

    public override void Upgrade()
    {

        Debug.Log("StorageSHIP Upgarded");
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

