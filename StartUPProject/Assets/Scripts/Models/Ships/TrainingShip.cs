using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingShip : Ship
{
    public override void OnShipBuy()
    {
        throw new System.NotImplementedException();
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
        return new TrainingShip();
    }

    public override void OnDestroy()
    {
        throw new System.NotImplementedException();
    }
}
