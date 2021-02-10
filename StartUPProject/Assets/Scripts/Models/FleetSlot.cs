using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetSlot : MonoBehaviour
{
    [SerializeField]
    ShipTypes shipType;

    public ShipTypes ShipType {get{ return shipType; }}

    public bool IsEmpty { get; set; } = true;
}
