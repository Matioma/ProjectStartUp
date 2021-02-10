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
        Debug.Log("Defence Ship Upgraded");
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
