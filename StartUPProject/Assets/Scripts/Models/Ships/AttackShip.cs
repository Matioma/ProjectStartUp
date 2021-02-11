using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShip :Ship
{
    public override void OnShipBuy()
    {
        Debug.Log("AttackShip received");
    }

    public override void Update()
    {
        Debug.Log("This is AttackShip");
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
