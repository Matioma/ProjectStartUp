using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetSlot : MonoBehaviour
{

    IShipActions shipActions;

    [SerializeField]
    ShipTypes shipType;

    public ShipTypes ShipType {get{ return shipType; }}
    public bool IsEmpty { get; set; } = true;


    public void FillSlot(IShipActions shipActions) {
        IsEmpty = false;
        this.shipActions = shipActions; 
    }

    public void FreeSlot() {
        IsEmpty = true;
        shipActions.OnDestroy();
        shipActions = null;
    }
}
