using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetModel : MonoBehaviour, IExpanding
{

    [Header("Configuration")]
    [SerializeField]
    StorageConfiguration storageConfiguration;

    [SerializeField]
    ShipSlot[] shipSlots;


    Storage fleetResourses;


    private void Awake()
    {
        if (storageConfiguration == null) { Debug.LogError("Make sure that the Fleet model has Storage configuration set up"); }
        fleetResourses = new Storage(storageConfiguration.gold, storageConfiguration.oranges, storageConfiguration.wood);
    }


    public void AddShip(ShipTypes shipType)
    {
        IShipActions newShip;
        switch (shipType){
            case ShipTypes.MainShip:
                newShip = new MainShip().CreateShip(this);
                break;
            case ShipTypes.DefenceShip:
                newShip = new DefenceShip().CreateShip(this);
                break;
            case ShipTypes.StorageShip:
                newShip = new StorageShip().CreateShip(this);
                break;
            case ShipTypes.TrainingShip:
                newShip = new TrainingShip().CreateShip(this);
                break;
        }
    }
}
