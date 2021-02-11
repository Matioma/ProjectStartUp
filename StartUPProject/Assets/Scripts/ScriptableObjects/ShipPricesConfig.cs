using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipPricesConfig", order = 1)]
public class ShipPricesConfig : ScriptableObject
{
    [SerializeField]
    public ShipPrice storageShipPrice;
    [SerializeField]
    public ShipPrice attackShipPrice;
    [SerializeField]
    public ShipPrice defenceShipPrice;
}
