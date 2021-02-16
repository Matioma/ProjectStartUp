using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class MainShipUpgrade
{
    [SerializeField]
    public int maxAttackShips;
    [SerializeField]
    public int maxDefenceShips;
}
public class MainShip : Ship
{
    public int woodStorage = 50;
    public int goldStorage = 50;
    public int orangeStorage = 50;
    public override void OnShipBuy()
    {
        base.OnShipBuy();
        this.AddStorage(goldStorage, woodStorage, orangeStorage);
        ApplyFleetUpgrades();
    }

    public override void Update()
    {
        
    }

    public override void Upgrade()
    {
        //fleetModel.FleetData

        fleetModel.IncreaseFleetLevel();
        if (upgradesConfiguration == null)
        {
            Debug.LogError("This ship was not configured");
        }

        if (fleetModel.FleetLevel - 1 >= this.upgradesConfiguration.MainShipUpgrades.Length)
        {
            Debug.Log("MainShip reached its max Level");
            return;
        }


        MainShipUpgrade upgradeData = this.upgradesConfiguration.MainShipUpgrades[fleetModel.FleetLevel - 1];
        fleetModel.FleetData.IncreaseAttackShipsCapacity(upgradeData.maxAttackShips);
        fleetModel.FleetData.IncreaseDefenceShipsCapacity(upgradeData.maxAttackShips);
    }
    public override void ApplyFleetUpgrades()
    {
        for (int i = 0; i < fleetModel.FleetLevel; i++)
        {
            if (i >= this.upgradesConfiguration.MainShipUpgrades.Length) { return; }

            MainShipUpgrade upgradeData = upgradesConfiguration.MainShipUpgrades[i];
            fleetModel.FleetData.IncreaseAttackShipsCapacity(upgradeData.maxAttackShips);
            fleetModel.FleetData.IncreaseDefenceShipsCapacity(upgradeData.maxAttackShips);
        }
    }
    public override IShipActions CreateShip(FleetModel fleetModel, ShipPrice price)
    {
        base.CreateShip(fleetModel,price);
        return this;
    }
    public override void OnDestroy()
    {
        this.ReduceStorage(goldStorage, woodStorage, orangeStorage);
    }
}
