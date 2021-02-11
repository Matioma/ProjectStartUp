using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipActions
{
    void Selected();
    void Update();
    void OnShipBuy();
    void Upgrade();
    void OnDestroy();

    void Configure(ShipUpgradesConfiguration config);
}
