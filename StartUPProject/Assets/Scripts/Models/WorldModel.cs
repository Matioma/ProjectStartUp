using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldModel : MonoBehaviour
{

    [SerializeField]
    GameObject worldFleetPrefab;
    [SerializeField]
    GameObject playerFleetPrefab;

    [SerializeField]
    List<WorldFleetData> fleets;

    private void Awake()
    {
        UpdateWorldMap();
    }

    public void AddFleetData(WorldFleetData fleetData) {
        fleets.Add(fleetData);
    }

    public void UpdateWorldMap()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        foreach (var fleet in fleets) {
            GameObject obj = null;
            if (fleet.isPlayer)
            {
                //Debug.Log("Is Player");
                obj =Instantiate(playerFleetPrefab, transform);
            }
            else {
                obj =Instantiate(worldFleetPrefab, transform);
            }



            //var obj = Instantiate(worldFleetPrefab, transform);
            obj.GetComponent<WorldFleetBehaviour>().Init(fleet);
            obj.transform.position = new Vector3(fleet.position.x, transform.position.y, fleet.position.y); 
        }
    }


    public void DeselectAllShips() {
        foreach (var fleet in GetComponentsInChildren<WorldFleetBehaviour>()) {
            fleet.DeselectShip();
        }
    }
}
