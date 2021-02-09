using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetModel : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField]
    StorageConfiguration storageConfiguration;

    Storage fleetResourses;

    private void Awake()
    {
        if (storageConfiguration == null) { Debug.LogError("Make sure that the Fleet model has Storage configuration set up"); }


        fleetResourses = new Storage(storageConfiguration.gold, storageConfiguration.oranges, storageConfiguration.wood);

        Debug.Log(fleetResourses.getBalance(ResourceType.Gold));
    }

}
