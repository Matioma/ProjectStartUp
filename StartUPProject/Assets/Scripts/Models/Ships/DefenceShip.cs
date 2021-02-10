using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceShip : Ship
{
    public override void OnShipBuy()
    {
        //Debug.Log("DefenceShip received");
    }

    public override void Update()
    {
        Debug.Log("This is SpaceShip");
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
