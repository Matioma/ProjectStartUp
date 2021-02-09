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
    public abstract void OnShipBuy();
    public abstract void Update();
    public abstract void UpdateSelf();
    public  abstract IShipActions CreateShip(FleetModel fleetModel);
}
