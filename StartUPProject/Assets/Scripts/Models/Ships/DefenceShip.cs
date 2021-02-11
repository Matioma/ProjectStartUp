using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DefenceShipUpgrade
{
    [SerializeField]
    int crewMembers;

    [SerializeField]
    public int woodConsumption;
    [SerializeField]
    public int goldConsumption;
    [SerializeField]
    public int orangeConsumption;
}

public class DefenceShip : Ship
{
    public override void OnShipBuy()
    {
        base.OnShipBuy();
        ApplyFleetUpgrades();
        //Debug.Log("DefenceShip received");

    }
    public override void Update()
    {
        base.Update();
        Debug.Log(fleetModel.FleetResources.GetBalance(ResourceType.Oranges));
    }


    public override void Upgrade()
    {
        if (upgradesConfiguration == null)
        {
            Debug.LogError("This ship was not configured");
        }

        if (fleetModel.FleetLevel - 1 >= this.upgradesConfiguration.DefenceShipUpgrades.Length)
        {
            Debug.Log("Defence Ship reached its max Level");
            return;
        }


        DefenceShipUpgrade upgradeData = this.upgradesConfiguration.DefenceShipUpgrades[fleetModel.FleetLevel - 1];
        woodConsumption += upgradeData.woodConsumption;
        goldConsumption += upgradeData.goldConsumption;
        orangeConsumption += upgradeData.orangeConsumption;
    }


    public override void ApplyFleetUpgrades()
    {
        for (int i = 0; i < fleetModel.FleetLevel; i++)
        {
            if (i >= this.upgradesConfiguration.DefenceShipUpgrades.Length) { return; }

            DefenceShipUpgrade upgradeData = upgradesConfiguration.DefenceShipUpgrades[i];
            woodConsumption += upgradeData.woodConsumption;
            goldConsumption += upgradeData.goldConsumption;
            orangeConsumption += upgradeData.orangeConsumption;
        }
    }

    public override IShipActions CreateShip(FleetModel fleetModel, ShipPrice price)
    {
        base.CreateShip(fleetModel,price);
        return this;
    }

    public override void OnDestroy()
    {
        throw new System.NotImplementedException();
    }
}
