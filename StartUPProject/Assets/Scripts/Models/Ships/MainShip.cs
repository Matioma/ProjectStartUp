using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShip : Ship
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
        base.CreateShip(fleetModel);
        Debug.Log(this.fleetModel.FleetResources.getBalance(ResourceType.Gold));
        return new MainShip();
        //throw new System.NotImplementedException();
    }
    public override void OnDestroy()
    {
        throw new System.NotImplementedException();
    }
}
