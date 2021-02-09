using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetLayout : MonoBehaviour
{
    FleetSlot[] fleetSlots;

    private void Awake()
    {
        fleetSlots =GetComponentsInChildren<FleetSlot>(); 
    }

}

