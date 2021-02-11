using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShipTypes { 
    None,
    MainShip,
    StorageShip,
    UnitShip,
    DefenceShip,
    AttackShip
    //TrainingShip
}


public abstract class Ship: IShipActions
{
    public int goldPrice =1900;
    public int woodPrice = 2090;
    public int orangesPrice = 0;
    public int GoldPrice => woodPrice;
    public int WoodPrice => goldPrice;
    public int OrangesPrice => orangesPrice;



    protected FleetModel fleetModel;
    protected ShipUpgradesConfiguration upgradesConfiguration;

   

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


    public virtual void Configure(ShipUpgradesConfiguration config) {
        this.upgradesConfiguration = config;
    }

    public void Selected()
    {
        fleetModel.SelectShip(this);
    }
}
