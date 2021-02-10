using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FleetLayout))]
public class FleetModel : MonoBehaviour, IFleetAction
{

    [Header("Configuration")]
    [SerializeField]
    StorageConfiguration storageConfiguration;
    [SerializeField]
    ShipFactoryConfiguration shipFactoryConfiguration;



    [Header("Class Data")]

    Storage fleetResourses;

    FleetLayout fleetLayout;


    private void Awake()
    {
        if (storageConfiguration == null) { Debug.LogError("Make sure that the Fleet model has Storage configuration set up"); }
        fleetResourses = new Storage(storageConfiguration.gold, storageConfiguration.oranges, storageConfiguration.wood);
        fleetLayout= GetComponent<FleetLayout>();
    }

    public void AddShip(ShipTypes shipType)
    {
        IShipActions newShip= null;
        switch (shipType)
        {
            case ShipTypes.MainShip:
                newShip = new MainShip().CreateShip(this);
                if (fleetLayout.CanAddShip(ShipTypes.MainShip))
                {
                    fleetLayout.FillSlot(newShip, shipFactoryConfiguration.BaseShipPrefab);
                }

                break;
            case ShipTypes.DefenceShip:
                newShip = new DefenceShip().CreateShip(this);
                fleetLayout.FillSlot(newShip, shipFactoryConfiguration.DefenceShipPrefab);
                if (fleetLayout.CanAddShip(ShipTypes.DefenceShip))
                {
                    fleetLayout.FillSlot(newShip, shipFactoryConfiguration.BaseShipPrefab);
                }
                break;
            case ShipTypes.StorageShip:
                newShip = new StorageShip().CreateShip(this);
                fleetLayout.FillSlot(newShip, shipFactoryConfiguration.StorageShipPrefab);
                break;
            case ShipTypes.TrainingShip:
                newShip = new TrainingShip().CreateShip(this);
                fleetLayout.FillSlot(newShip, shipFactoryConfiguration.TrainingShipPrefab);
                break;
            default:
                Debug.LogError("Unkown Ship Type");
                break;
        }
    }
}
