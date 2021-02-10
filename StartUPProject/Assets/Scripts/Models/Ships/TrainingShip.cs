using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingShip : Ship
{

    public override void OnShipBuy()
    {
    }

    public override void Update()
    {
        Debug.Log("This is Trainining Ship");
    }

    public override void Upgrade()
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
