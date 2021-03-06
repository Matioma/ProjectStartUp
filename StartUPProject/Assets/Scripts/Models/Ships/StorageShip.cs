using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StorageShipUpgrade {
    [SerializeField]
    public int woodStorage;
    [SerializeField]
    public int goldStorage;
    [SerializeField]
    public int orangeStorage;

    [SerializeField]
    public int woodConsumption;
    [SerializeField]
    public int goldConsumption;
    [SerializeField]
    public int orangeConsumption;
}
public class StorageShip : Ship
{



    public override void OnShipBuy()
    {
        base.OnShipBuy();
        ApplyFleetUpgrades();
    }

    public override void Update()
    {
        base.Update();
    }


    public override void ApplyFleetUpgrades()
    {
        for (int i = 0; i < fleetModel.FleetLevel; i++)
        {
            if (i >= this.upgradesConfiguration.StorageUpgrades.Length) { return; }

            StorageShipUpgrade upgradeData = this.upgradesConfiguration.StorageUpgrades[i];
            AddStorage(upgradeData.goldStorage, upgradeData.woodStorage, upgradeData.orangeStorage);
        }
    }



    public override void Upgrade()
    {
        if (upgradesConfiguration == null) {
            Debug.LogError("This ship was not configured");
        }

        if (fleetModel.FleetLevel - 1 >= this.upgradesConfiguration.StorageUpgrades.Length) {
            Debug.Log("Storage Ship reached its max Level");    
            return; 
        }
        StorageShipUpgrade upgradeData = this.upgradesConfiguration.StorageUpgrades[fleetModel.FleetLevel-1];
        AddStorage(upgradeData.goldStorage, upgradeData.woodStorage, upgradeData.orangeStorage);
    }

    public override IShipActions CreateShip(FleetModel fleetModel, ShipPrice price)
    {
        base.CreateShip(fleetModel, price);
        return this;
    }

    public override void OnDestroy()
    {
       // this.ReduceStorage(initialGoldStorage, initialWoodStorage, initialOrangeStorage);
    }

  
}

