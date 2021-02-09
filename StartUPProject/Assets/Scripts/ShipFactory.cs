using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFactory :ScriptableObject, IShipFactory
{
    [SerializeField]
    GameObject DefenceShipPrefab;
    [SerializeField]
    GameObject MainShipPrefab;
    [SerializeField]
    GameObject StorageShipPrefab;
    [SerializeField]
    GameObject TrainingShipPrefab;

    public Ship CreateDefenceShip()
    {
        throw new System.NotImplementedException();
    }
    public Ship CreateMainShip()
    {
        throw new System.NotImplementedException();
    }
    public Ship CreateStorageShip()
    {
        throw new System.NotImplementedException();
    }
    public Ship CreateTrainingShip()
    {
        throw new System.NotImplementedException();
    }
}
