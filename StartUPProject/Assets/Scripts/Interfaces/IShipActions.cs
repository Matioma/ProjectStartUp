using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipActions
{
    int GoldPrice { get; }
    int WoodPrice { get; }
    int OrangesPrice { get; }

    void Selected();
    void Update();
    void OnShipBuy();
    void Upgrade();
    void OnDestroy();

    void Configure(ShipUpgradesConfiguration config);
}
