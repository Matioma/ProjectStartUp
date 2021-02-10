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

    protected void AddStorage(int gold, int wood, int oranges) {
        fleetModel.FleetResources.IncreaseStorage(ResourceType.Gold,gold);
        fleetModel.FleetResources.IncreaseStorage(ResourceType.Wood, wood);
        fleetModel.FleetResources.IncreaseStorage(ResourceType.Oranges, oranges);
    }
    protected void ReduceStorage(int gold, int wood, int oranges) {
      
        fleetModel.FleetResources.DecreaseStorage(ResourceType.Gold, gold);
        fleetModel.FleetResources.DecreaseStorage(ResourceType.Wood, wood);
        fleetModel.FleetResources.DecreaseStorage(ResourceType.Oranges, oranges);
    }

    public abstract void OnShipBuy();
    public abstract void Update();
    public abstract void Upgrade();

    public abstract void OnDestroy();
    public virtual IShipActions CreateShip(FleetModel fleetModel) {
        this.fleetModel = fleetModel;
        return this;
    }
 
}
