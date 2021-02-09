using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipFactory
{
    Ship CreateMainShip();
    Ship CreateStorageShip();
    Ship CreateDefenceShip();
    Ship CreateTrainingShip();
}
