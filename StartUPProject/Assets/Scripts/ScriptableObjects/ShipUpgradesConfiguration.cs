using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipUpgradesConfiguration", order = 1)]
public class ShipUpgradesConfiguration : ScriptableObject
{
    [SerializeField]
    MainShipUpgrade[] mainShipUpgrades;
    public MainShipUpgrade[] MainShipUpgrades => mainShipUpgrades;

    [SerializeField]
    StorageShipUpgrade[] storageUpgrades;
    public StorageShipUpgrade[] StorageUpgrades{get{ return storageUpgrades; }}


    [SerializeField]
    AttackShipUpgrade[] attackShipUpgrades;
    public AttackShipUpgrade[] AttackShipUpgrades => attackShipUpgrades;


    [SerializeField]
    DefenceShipUpgrade[] defenceShipUpgrades;
    public DefenceShipUpgrade[] DefenceShipUpgrades => defenceShipUpgrades;
}
