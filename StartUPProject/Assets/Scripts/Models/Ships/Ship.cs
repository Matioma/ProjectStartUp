using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShipTypes { 
    None,
    MainShip,
    StorageShip,
    DefenceShip,
    TrainingShip
}


public abstract class Ship: IShipActions
{
    protected FleetModel fleetModel;

    public abstract void OnShipBuy();
    public abstract void Update();
    public abstract void UpdateSelf();

    public abstract void OnDestroy();
    public virtual IShipActions CreateShip(FleetModel fleetModel) {
        this.fleetModel = fleetModel;
        return this;
    }
 
}
