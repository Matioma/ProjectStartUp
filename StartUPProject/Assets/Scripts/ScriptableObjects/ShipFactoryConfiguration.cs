using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipFactoryConfiguration", order = 1)]
public class ShipFactoryConfiguration : ScriptableObject
{
    [SerializeField]
    public GameObject BaseShipPrefab;
    [SerializeField]
    public GameObject StorageShipPrefab;
    [SerializeField]
    public GameObject AttackShipPrefab;
    [SerializeField]
    public GameObject DefenceShipPrefab;
}
