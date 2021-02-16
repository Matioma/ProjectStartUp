using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryResources : MonoBehaviour
{
    [SerializeField]
    FleetModel fleetModel;

    [SerializeField]
    int gold;
    public int Gold => gold;
    
    [SerializeField]
    int wood;
    public int Wood => wood;
    
    [SerializeField]
    int oranges;
    public int Oranges => oranges;

    private void OnEnable()
    {
        gold = Random.Range(10, 100) * 10;
        wood = Random.Range(10, 100) * 10;
        oranges = Random.Range(10, 100) * 10;
    }

    public void SendResources() {
        fleetModel.FleetResources.AddResource(ResourceType.Gold, gold);
        fleetModel.FleetResources.AddResource(ResourceType.Oranges, oranges);
        fleetModel.FleetResources.AddResource(ResourceType.Wood, wood);
    }
}
