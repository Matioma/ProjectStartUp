using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipUpgradesConfiguration", order = 1)]
public class ShipUpgradesConfiguration : ScriptableObject
{
    [SerializeField]
    StorageShipUpgrade[] storageUpgrades;
    public StorageShipUpgrade[] StorageUpgrades{get{ return storageUpgrades; }}
}
