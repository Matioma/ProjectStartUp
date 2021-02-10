using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetSlot : MonoBehaviour
{
    [SerializeField]
    ShipTypes ShipType;

    public bool IsEmpty { get; set; } = true;
}
