using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetSlot : MonoBehaviour
{

    IShipActions shipActions;
    public IShipActions ShipAction { get { return shipActions; } }

    [SerializeField]
    ShipTypes shipType;

    public ShipTypes ShipType { get { return shipType; } }
    public bool IsEmpty { get; set; } = true;



    float timeBetweenActions = 10.0f;
    float timer;




    private void Update()
    {
        if (shipActions != null) {
            if (timer < 0) {
                shipActions.Update();
                timer = timeBetweenActions;
            }
            timer -= Time.deltaTime;
        }
    }


    public void FillSlot(IShipActions shipActions, GameObject prefab) {
        IsEmpty = false;
        this.shipActions = shipActions;
        Instantiate(prefab, transform);
        timer = timeBetweenActions;
    }

    public bool TryFreeSlot(IShipActions ship) {
        if (ship != shipActions) return false;

        IsEmpty = true;
        shipActions.OnDestroy();
        shipActions = null;
        RemoveAllChildren();
        return true;
    }

    public void Selected()
    {
        Debug.Log("Selected");
        shipActions.Selected();
    }

    void RemoveAllChildren() {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

}
