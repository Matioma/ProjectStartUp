using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    IFleetAction fleetActions;
    IShipActions shipActions;
    
    private void Start()
    {
        fleetActions = FindObjectOfType<FleetModel>();
    }

    public void UpdateShip() {
        fleetActions.GetSelectedShip().Update();
    }

    public void DeselectShip() {

        fleetActions.DeselectShip();
        //fleetActions.GetSelectedShip()
    }
}
