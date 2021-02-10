using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipActionsView : MonoBehaviour
{
    FleetModel fleetModel;

    public void Init(FleetModel fleetModel)
    {
        this.fleetModel = fleetModel;
    }

    public virtual void Display()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
