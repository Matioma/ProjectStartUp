using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ResourceType { 
    Oranges,
    Gold,
    Wood
}

[System.Serializable]
public class Storage
{
    [SerializeField]
    Dictionary<ResourceType, int> _userBalance = new Dictionary<ResourceType, int>();



    public Storage(int gold, int oranges, int wood) {
        _userBalance[ResourceType.Gold] = gold;
        _userBalance[ResourceType.Oranges] = oranges;
        _userBalance[ResourceType.Wood] = wood;
    }


    public int getBalance(ResourceType resourceType)
    {
        return _userBalance[resourceType];
    }

    public bool AddResource(ResourceType resourceType,int amount) {
        if (amount > 0) {
            _userBalance[resourceType] += amount;
            return true;
        }

        return false;
    }

    
    public bool UseResources(ResourceType resourceType, int amount) {
        if (_userBalance[resourceType] > amount) {
            _userBalance[resourceType] -= amount;
            return true;
        }
        return false;
    }

}
