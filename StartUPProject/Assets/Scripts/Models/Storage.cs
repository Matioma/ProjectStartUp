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

    [SerializeField]
    Dictionary<ResourceType, int> _maxStorage = new Dictionary<ResourceType, int>();


    public Storage(int gold, int oranges, int wood) {
        _userBalance[ResourceType.Gold] = gold;
        _userBalance[ResourceType.Oranges] = oranges;
        _userBalance[ResourceType.Wood] = wood;

        _maxStorage[ResourceType.Gold] = 0;
        _maxStorage[ResourceType.Oranges] = 0;
        _maxStorage[ResourceType.Wood] = 0;
    }

    public int GetStorageCap(ResourceType resourceType) {
        return _maxStorage[resourceType];
    }

    public void IncreaseStorage(ResourceType resourceType, int amount) {
        if (amount < 0)
        {
            Debug.LogWarning(" You are incrising the storage by a negative amount => you actually decrease it");
        }
        _maxStorage[resourceType] += amount;
    }
    public bool DecreaseStorage(ResourceType resourceType, int amount)
    {
        if (amount < 0) {
            Debug.LogWarning(" You are decreaseing the storage by a negative amount => you actually increase it");
        }

        if (amount > 0) {
            _maxStorage[resourceType] = 0;
            return false;
        }
        _maxStorage[resourceType] -= amount;
        return true;
    }

    public int GetBalance(ResourceType resourceType)
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
