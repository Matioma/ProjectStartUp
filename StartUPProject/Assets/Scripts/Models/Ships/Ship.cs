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
    ShipPrice buildPrice;
    public int GoldPrice => buildPrice.goldPrice;
    public int WoodPrice => buildPrice.woodPrice;
    public int OrangesPrice => buildPrice.orangesPrice;


    protected int woodConsumption;
    protected int goldConsumption;
    protected int orangeConsumption;



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
    public virtual void OnShipBuy() {
        fleetModel.FleetResources.UseResources(ResourceType.Gold, buildPrice.goldPrice);
        fleetModel.FleetResources.UseResources(ResourceType.Oranges, buildPrice.orangesPrice);
        fleetModel.FleetResources.UseResources(ResourceType.Wood, buildPrice.woodPrice);
    }
    public virtual void Update() {
        fleetModel.FleetResources.UseResources(ResourceType.Wood, woodConsumption);
        fleetModel.FleetResources.UseResources(ResourceType.Gold, goldConsumption);
        fleetModel.FleetResources.UseResources(ResourceType.Oranges, orangeConsumption);
    }
    public abstract void Upgrade();

    public abstract void ApplyFleetUpgrades();

    public abstract void OnDestroy();
    public virtual IShipActions CreateShip(FleetModel fleetModel, ShipPrice buildPrice) {
        this.fleetModel = fleetModel;
        this.buildPrice = buildPrice;
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
