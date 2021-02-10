using System;
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
    public Storage FleetResources { get { return fleetResourses; } }




    List<IShipActions> allShips = new List<IShipActions>();


    FleetLayout fleetLayout;


    int fleetLevel = 1;
    public int FleetLevel {get{ return fleetLevel; }}


    public event Action onFleetDataChanged;

    private void Awake()
    {
        if (storageConfiguration == null) { Debug.LogError("Make sure that the Fleet model has Storage configuration set up"); }
        fleetResourses = new Storage(storageConfiguration.gold, storageConfiguration.oranges, storageConfiguration.wood);
        fleetLayout= GetComponent<FleetLayout>();
        
    }

    void Start() {
        AddShip(ShipTypes.MainShip);
    }

    public void AddShip(ShipTypes shipType)
    {
        IShipActions newShip= null;

        bool shipAdded = false;

        switch (shipType)
        {
            case ShipTypes.MainShip:
                newShip = new MainShip().CreateShip(this);
                shipAdded=fleetLayout.FillSlot(newShip, shipFactoryConfiguration.BaseShipPrefab,shipType);
                break;
            case ShipTypes.DefenceShip:
                newShip = new DefenceShip().CreateShip(this);
                shipAdded= fleetLayout.FillSlot(newShip, shipFactoryConfiguration.DefenceShipPrefab, shipType);
                break;
            case ShipTypes.StorageShip:
                newShip = new StorageShip().CreateShip(this);
                shipAdded= fleetLayout.FillSlot(newShip, shipFactoryConfiguration.StorageShipPrefab, shipType);
                break;
            case ShipTypes.TrainingShip:
                newShip = new TrainingShip().CreateShip(this);
                shipAdded= fleetLayout.FillSlot(newShip, shipFactoryConfiguration.TrainingShipPrefab, shipType);
                break;
            default:
                Debug.LogError("Unkown Ship Type");
                break;
        }

        if (shipAdded) {
            onFleetDataChanged?.Invoke();
            fleetLayout.GetShips(typeof(Ship));
        }
    }


    public void RemoveShip(IShipActions ship) { 
    }
    public void IncreaseFleetLevel() {
        fleetLevel++;
        foreach (var ship in fleetLayout.GetShips(typeof(Ship))) {
            ship.Upgrade();
        }
    }
    

    
}
