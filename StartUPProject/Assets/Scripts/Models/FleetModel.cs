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
    [SerializeField]
    ShipUpgradesConfiguration upgradesConfig;
    public ShipUpgradesConfiguration UpgradesConfig => upgradesConfig;

    [SerializeField]
    ShipPricesConfig pricesConfig;


    [Header("Class Data")]
    Storage fleetResourses;
    public Storage FleetResources { get { return fleetResourses; } }

    FleetLayout fleetLayout;

    FleetData fleetData;
    public FleetData FleetData => fleetData;


    int fleetLevel = 1;
    public int FleetLevel {get{ return fleetLevel; }}


    Ship selectedShip = null;

    public event Action onFleetDataChanged;

    public event Action onSelectionChanged;
    public event Action onShipSelected;
    public event Action onShipDeselected;

    private void Awake()
    {
        if (storageConfiguration == null) { Debug.LogError("Make sure that the Fleet model has Storage configuration set up"); }
        fleetResourses = new Storage(storageConfiguration.gold, storageConfiguration.oranges, storageConfiguration.wood);
        fleetData = new FleetData();

        fleetLayout = GetComponent<FleetLayout>();

        fleetResourses.onStorageChange += UpdateUI;
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
                newShip = new MainShip().CreateShip(this, new ShipPrice());
                shipAdded = fleetLayout.FillSlot(newShip, shipFactoryConfiguration.BaseShipPrefab, shipType);
                break;
            case ShipTypes.DefenceShip:
                newShip = new DefenceShip().CreateShip(this, pricesConfig.defenceShipPrice);
                if (CanBuy(newShip) && fleetData.HasAvailableSlot(typeof(DefenceShip), fleetLayout.GetShips(typeof(DefenceShip)).Count))
                {
                    shipAdded = fleetLayout.FillSlot(newShip, shipFactoryConfiguration.DefenceShipPrefab, shipType);
                }
                break;
            case ShipTypes.StorageShip:
                newShip = new StorageShip().CreateShip(this, pricesConfig.storageShipPrice);
                if (CanBuy(newShip))
                {
                    shipAdded = fleetLayout.FillSlot(newShip, shipFactoryConfiguration.StorageShipPrefab, shipType);
                }
                break;
            case ShipTypes.AttackShip:
                newShip = new AttackShip().CreateShip(this, pricesConfig.attackShipPrice);
                if (CanBuy(newShip) && fleetData.HasAvailableSlot(typeof(DefenceShip), fleetLayout.GetShips(typeof(AttackShip)).Count))
                {
                    shipAdded = fleetLayout.FillSlot(newShip, shipFactoryConfiguration.AttackShipPrefab, shipType);
                }
                break;
        
            default:
                Debug.LogError("Unkown Ship Type");
                break;
        }



        if (shipAdded) {
            onFleetDataChanged?.Invoke();
            //fleetLayout.GetShips(typeof(Ship));
        }
    }

    private void removeShip(IShipActions ship) {
        if (ship == null) return; 
        fleetLayout.RemoveShip(ship);
        onFleetDataChanged?.Invoke();
    }
    public void AbandomShip()
    {
        removeShip(selectedShip);
    }

    public void IncreaseFleetLevel() {
        fleetLevel++;
        foreach (var ship in fleetLayout.GetShips(typeof(Ship))) {
            if (ship.GetType() != typeof(MainShip))
                ship.Upgrade();
        }
        onFleetDataChanged?.Invoke();
    }


    public int GetShipsCount(Type shipType) {
        return fleetLayout.GetShips(shipType).Count;
    }

    void UpdateUI()
    {
        onFleetDataChanged?.Invoke();
    }

    public void SelectShip(Ship ship)
    {
        selectedShip = ship;
        onSelectionChanged?.Invoke();
    }
    public void DeselectShip() {
        selectedShip = null;
        onSelectionChanged?.Invoke();
    }

    public Ship GetSelectedShip()
    {
        return selectedShip;
    }

    protected bool CanBuy(IShipActions ship) {
        return fleetResourses.CanSpend(ship.GoldPrice, ship.OrangesPrice, ship.WoodPrice);
    }

    void OnDestroy() {
        fleetResourses.onStorageChange -= UpdateUI;
    }

    
}
