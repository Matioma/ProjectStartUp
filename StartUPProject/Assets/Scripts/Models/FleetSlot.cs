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


    public void FillSlot(IShipActions shipActions, GameObject prefab) {
        IsEmpty = false;
        this.shipActions = shipActions;
        Instantiate(prefab, transform);
    }

    public void FreeSlot(IShipActions ship) {
        if (ship != shipActions) return;

        IsEmpty = true;
        shipActions.OnDestroy();
        shipActions = null;

        RemoveAllChildren();


    }

    void RemoveAllChildren() {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

    }

}
