using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShip : Ship
{
    public int woodStorage = 50;
    public int goldStorage = 50;
    public int orangeStorage = 50;
    public override void OnShipBuy()
    {
        this.AddStorage(goldStorage, woodStorage, orangeStorage);
    }

    public override void Update()
    {
        
    }

    public override void Upgrade()
    {
        Debug.Log("Main SHIP UPGARDED");
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
